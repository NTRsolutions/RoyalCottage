using RoyalCottage.Framework.Core.Models;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoyalCottage.Framework.Domain
{
    public abstract class EntityService<T> : IEntityService<T>
        where T : CouchbaseTenantEntityBase
    {
        protected abstract ICouchbaseRepository<T> Repository { get; } 

        public async virtual Task<BusinessResponse<T>> DeleteAsync<TKey>(Guid tenantId, TKey id)
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            return await Repository.SoftRemoveAsync(entity.Key);
        }

        public async virtual Task<BusinessResponse<T>> GetAllAsync(Guid tenantId)
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId });
            return await Repository.GetAllAsync(tenantId, entity.TypeId);
        }

        public async virtual Task<BusinessResponse<T>> GetAsync<TKey>(Guid tenantId, TKey id)
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            return await Repository.GetAsync(entity.Key);
        }

        public async virtual Task<BusinessResponse<T>> CreateAsync(T data)
        {
            if (data.Id == null || data.Id == new Guid()) data.Id = Guid.NewGuid();
            data.IsActive = "TRUE";
            return await Repository.InsertAsync(data);
        }

        public async Task<BusinessResponse<T>> UpdateAsync(T data)
        {
            return await Repository.UpdateAsync(data);
        }

        /// <summary>
        /// Get the value of a particular child property 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<TChild>> GetChildAsync<TKey, TChild>(Guid tenantId, TKey id, string childName)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.GetChildAsync<TChild>(entity.Key, childName);
        }

        /// <summary>
        /// Get the values of a particular collection child property
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<TChild>> GetChildAllAsync<TKey, TChild>(Guid tenantId, TKey id, string childName)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.GetChildAsync<TChild>(entity.Key, childName, true);
        }

        /// <summary>
        /// Add a new child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> CreateChildAsync<TChild>(Guid tenantId, Guid id, string childName, TChild data)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.InsertChildAsync<TChild>(entity.Key, childName, data);
        }

        /// <summary>
        /// Add a new collection child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> CreateChildAsync<TChild>(Guid tenantId, Guid id, string childName, List<TChild> data)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.InsertChildAsync<TChild>(entity.Key, childName, data);
        }

        /// <summary>
        /// Add a new value to a Collection Child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> CreateCollectionChildAsync<TChild>(Guid tenantId, Guid id, string childName, TChild data)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.InsertChildAsync<TChild>(entity.Key, childName, data, true);
        }

        /// <summary>
        /// Update a collection child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> UpdateChildAsync<TChild>(Guid tenantId, Guid id, string childName, List<TChild> data)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.UpdateChildAsync<TChild>(entity.Key, childName, data);
        }

        /// <summary>
        /// Delete a Child Element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> DeleteChildAsync<TChild>(Guid tenantId, Guid id, string childName)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.RemoveChildAsync<TChild>(entity.Key, childName);
        }

        /// <summary>
        /// Delete a value from a Collection Child Element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        public async virtual Task<BusinessResponse<T>> DeleteCollectionChildAsync<TChild>(Guid tenantId, Guid id, string childName, Guid childId)
            where TChild : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T), new object[] { tenantId, id });
            if (typeof(T).GetProperty(childName) == null) throw new ArgumentException($"{childName} is not a valid child of type {nameof(T)}");
            return await Repository.RemoveChildAsync<TChild>(entity.Key, childName, true, childId);
        }
    }
}
