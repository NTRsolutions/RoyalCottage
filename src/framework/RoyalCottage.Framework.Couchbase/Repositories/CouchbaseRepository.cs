using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoyalCottage.Framework.Couchbase.Models;
using Couchbase.N1QL;
using Couchbase.IO;
using RoyalCottage.Framework.Core.Models;
using System.Linq.Expressions;
using Couchbase;
using RoyalCottage.Framework.Core.Extensions;

namespace RoyalCottage.Framework.Couchbase.Repositories
{
    /// <summary>
    /// Key-value repository for Couchbase. Has generic implementation of CRUD operations
    /// for couchbase entities.
    /// </summary>
    /// <typeparam name="T">Any type inheriting from CouchbaseEntityBase</typeparam>
    /// <typeparam name="TKey">Type of the Id property of the entity</typeparam>
    public abstract class CouchbaseRepository<T> : ICouchbaseRepository<T>
        where T : CouchbaseTenantEntityBase
    {
        #region properties
        private ICouchbaseBucket _bucket;
        #endregion

        #region ctor
        public CouchbaseRepository(ICouchbaseBucket bucket)
        {
            _bucket = bucket;
        }
        #endregion

        #region Document Operations
        public virtual async Task<BusinessResponse<T>> GetAsync(string key)
        {
            var result = await _bucket.GetAsync<T>(key);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Ok;
                response.Data = result.Value;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        public async virtual Task<BusinessResponse<T>> InsertAsync(T data)
        {
            var result = await _bucket.InsertAsync<T>(data.Key, data);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Created;
                response.Message = result.Message;
                response.Data = (await GetAsync(data.Key)).Data;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        public async virtual Task<BusinessResponse<T>> RemoveAsync(string key)
        {
            var result = await _bucket.RemoveAsync(key);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Deleted;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Soft Delete the record by setting the IsActive property to false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> SoftRemoveAsync(string key)
        {
            var result = await _bucket.GetAsync<T>(key);
            result.Value.IsActive = "FALSE";
            result = await _bucket.UpsertAsync<T>(key, result.Value);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Deleted;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        public async virtual Task<BusinessResponse<T>> UpdateAsync(T data)
        {
            var result = await _bucket.UpsertAsync<T>(data.Key, data);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Updated;
                response.Message = result.Message;
                response.Data = (await GetAsync(data.Key)).Data;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Get rows by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> GetAsync(IQueryRequest query)
        {
            var result = await _bucket.QueryAsync<T>(query);

            var response = new BusinessResponse<T>();

            if (result.Success)
            {
                response.Status = BusinessStatus.Ok;
                response.DataList = result.Rows;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Get all records of a particular type
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public async Task<BusinessResponse<T>> GetAllAsync(Guid tenantId, Guid typeId)
        {
            var queryStatement = $"select {_bucket.BucketName}.* from {_bucket.BucketName} where tenantId=$tenantId and typeId=$typeId and isActive=UPPER($isActive)";
            var query = new QueryRequest()
                .Statement(queryStatement)
                .AddNamedParameter(new KeyValuePair<string, object>[] {
                    new KeyValuePair<string, object>("tenantId", tenantId.ToString().ToLower()),
                    new KeyValuePair<string, object>("typeId", typeId.ToString().ToLower()),
                    new KeyValuePair<string, object>("isActive", "true")
                });
            return await GetAsync(query);
        }
        #endregion

        #region Sub-Document Operations
        /// <summary>
        /// Get the value of a child property from a Couchbase document.
        /// </summary>
        /// <typeparam name="TChild">Type of the  child document</typeparam>
        /// <param name="key">The Couchbase document key</param>
        /// <param name="childName">The child property name</param>
        /// <param name="isCollection">Indicates if the child is a single element or a collection</param>
        /// <returns>BusinessResonse with the Data or DataList property populated, depending on the type of the child element</returns>
        public async virtual Task<BusinessResponse<TChild>> GetChildAsync<TChild>(string key, string childName, bool isCollection = false) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();
            var result = await _bucket.GetChildAsync<T>(key, childName);

            var response = new BusinessResponse<TChild>();

            if (result.Success && result.OpStatus(childName) == ResponseStatus.Success)
            {
                response.Status = BusinessStatus.Ok;
                if (isCollection)
                {
                    response.DataList = result.Content<List<TChild>>(childName);
                }
                else
                {
                    response.Data = result.Content<TChild>(childName);
                }
                
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Create a child element for a Couchbasae document. If the child element is CollectionType,
        /// then, insert the value as an element of collection property, else, insert a standalone child element.
        /// </summary>
        /// <typeparam name="TChild">Type of the  child document</typeparam>
        /// <param name="key">The Couchbase document key</param>
        /// <param name="childName">The child property name</param>
        /// <param name="data">The child element to be inserted</param>
        /// <param name="isCollection">Indicates if the child is a single element or a collection</param>
        /// <returns>BusinessResponse with Status as Created if the element is inserted correctly, otherwise,
        /// Error if the insert failed or the child element already exists.</returns>
        public async virtual Task<BusinessResponse<T>> InsertChildAsync<TChild>(string key, string childName, TChild data, bool isCollection = false) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();

            var result = isCollection
                ? await _bucket.InsertArrayChildAsync<T, TChild>(key, childName, data)
                : await _bucket.InsertChildAsync<T, TChild>(key, childName, data);

            var response = new BusinessResponse<T>();

            if (result.Success && result.OpStatus(0) == ResponseStatus.Success)
            {
                response.Status = BusinessStatus.Created;
                response.Message = result.Message;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Create a collection child element for the Couchbase document.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> InsertChildAsync<TChild>(string key, string childName, List<TChild> data) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();

            var result = await _bucket.InsertArrayChildAsync<T, TChild>(key, childName, data);

            var response = new BusinessResponse<T>();

            if (result.Success && result.OpStatus(0) == ResponseStatus.Success)
            {
                response.Status = BusinessStatus.Created;
                response.Message = result.Message;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }



        /// <summary>
        /// Update the subdocument for a given document key. If its a standalone element, then, it will
        /// be upserted. If it is a collection element, then, the collection item will be replaced if
        /// found, fail otherwise.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <param name="isCollection"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> UpdateChildAsync<TChild>(string key, string childName, TChild data, bool isCollection = false) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();

            var response = new BusinessResponse<T>();

            try
            {
                var result = isCollection
                ? await UpdateCollectionChildAsync(key, childName, data)
                : await _bucket.UpsertChildAsync<T, TChild>(key, childName, data);

                if (result.Success && result.OpStatus(0) == ResponseStatus.Success)
                {
                    response.Status = BusinessStatus.Updated;
                    response.Message = result.Message;
                }
                else
                {
                    response.Status = BusinessStatus.Error;
                    response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
                }
            }
            catch (Exception ex)
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = ex.Message } };
            }
            
            return response;
        }

        /// <summary>
        /// Create a collection child element for the Couchbase document.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> UpdateChildAsync<TChild>(string key, string childName, List<TChild> data) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();

            var result = await _bucket.UpsertChildAsync<T, TChild>(key, childName, data);

            var response = new BusinessResponse<T>();

            if (result.Success && result.OpStatus(0) == ResponseStatus.Success)
            {
                response.Status = BusinessStatus.Updated;
                response.Message = result.Message;
            }
            else
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
            }

            return response;
        }

        /// <summary>
        /// Removes a child document from a document if it is standalone child. For Collection
        /// Child, removes the element that matches the childId.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="isCollection"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> RemoveChildAsync<TChild>(string key, string childName, bool isCollection = false, Guid childId = default(Guid)) where TChild : EntityBase
        {
            childName = childName.ToCamelCase();

            var response = new BusinessResponse<T>();

            try
            {
                var result = isCollection
                ? await RemoveCollectionChildAsync<TChild>(key, childName, childId)
                : await _bucket.RemoveChildAsync<T>(key, childName);

                if (result.Success && result.OpStatus(0) == ResponseStatus.Success)
                {
                    response.Status = BusinessStatus.Deleted;
                    response.Message = result.Message;
                }
                else
                {
                    response.Status = BusinessStatus.Error;
                    response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
                }
            }
            catch (Exception ex)
            {
                response.Status = BusinessStatus.Error;
                response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = ex.Message } };
            }

            return response;
        }
        #endregion

        private async Task<IDocumentFragment<T>> UpdateCollectionChildAsync<TChild>(string key, string childName, TChild data) where TChild : EntityBase
        {
            var result = await _bucket.GetChildAsync<T>(key, childName);
            if (result.Status.Equals(ResponseStatus.Success))
            {
                var list = result.Content<List<TChild>>(childName);
                var index = list.FindIndex(x => x.Id == data.Id);
                if (index < 0)
                    throw new KeyNotFoundException("The given element does not exist in the child collection.");
                return await _bucket.UpdateArrayChildAsync<T, TChild>(key, childName, index, data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        private async Task<IDocumentFragment<T>> RemoveCollectionChildAsync<TChild>(string key, string childName, Guid childId) where TChild : EntityBase
        {
            var result = await _bucket.GetChildAsync<T>(key, childName);
            if (result.Status.Equals(ResponseStatus.Success))
            {
                var list = result.Content<List<TChild>>(childName);
                var index = list.FindIndex(x => x.Id == childId);
                if (index < 0)
                    throw new KeyNotFoundException("The given element does not exist in the child collection.");
                return await _bucket.RemoveArrayChildAsync<T>(key, childName, index);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

    }
}
