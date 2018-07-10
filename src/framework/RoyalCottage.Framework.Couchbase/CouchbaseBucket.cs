using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using RoyalCottage.Framework.Core.Extensions;

namespace RoyalCottage.Framework.Couchbase
{
    public class CouchbaseBucket : ICouchbaseBucket
    {
        private readonly IBucket _bucket;
        public string BucketName { get; }

        public CouchbaseBucket(ICouchbaseBucketProvider provider)
        {
            _bucket = provider.GetBucket();
            BucketName = _bucket.Name;
        }

        /// <summary>
        /// Get a Document and Locks it for a specified time async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        public async Task<IOperationResult<T>> GetAndLockAsync<T>(string key, TimeSpan expiration)
        {
            return await _bucket.GetAndLockAsync<T>(key.ToLower(), expiration);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>

        /// <returns></returns>
        public async Task<IOperationResult<T>> InsertAsync<T>(string key, T value)
        {
            return await _bucket.InsertAsync(key.ToLower(), value);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration</param>
        /// <returns></returns>
        public async Task<IOperationResult<T>> InsertAsync<T>(string key, T value, TimeSpan expiration)
        {
            return await _bucket.InsertAsync(key.ToLower(), value, expiration);
        }

        /// <summary>
        /// Upserts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public async Task<IOperationResult<T>> UpsertAsync<T>(string key, T value)
        {
            return await _bucket.UpsertAsync(key.ToLower(), value);
        }

        /// <summary>
        /// Upserts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration.</param>
        /// <returns></returns>
        public async Task<IOperationResult<T>> UpsertAsync<T>(string key, T value, TimeSpan expiration)
        {
            return await _bucket.UpsertAsync(key.ToLower(), value, expiration);
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<IOperationResult> RemoveAsync(string key)
        {
            return await _bucket.RemoveAsync(key.ToLower());
        }

        /// <summary>
        /// Gets by key asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<IOperationResult<T>> GetAsync<T>(string key)
        {
            return await _bucket.GetAsync<T>(key.ToLower());
        }

        /// <summary>
        /// Queries the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<IQueryResult<T>> QueryAsync<T>(IQueryRequest query)
        {
            return await _bucket.QueryAsync<T>(query);
        }



        /// <summary>
        /// Insert a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> InsertChildAsync<T, TChild>(string key, string childName, TChild value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Insert(childName, value, true)
                .ExecuteAsync();
        }

        /// <summary>
        /// Insert a collection subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> InsertArrayChildAsync<T, TChild>(string key, string childName, List<TChild> value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Insert(childName, value, true)
                .ExecuteAsync();
        }

        /// <summary>
        /// Gets a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> GetChildAsync<T>(string key, string childName)
        {
            return await _bucket.LookupIn<T>(key.ToLower())
                .Get(childName)
                .ExecuteAsync();

        }

        /// <summary>
        /// Insert or Update a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> UpsertChildAsync<T, TChild>(string key, string childName, TChild value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Upsert(childName, value, true)
                .ExecuteAsync();
        }

        /// <summary>
        /// Insert or Update a Collection subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> UpsertChildAsync<T, TChild>(string key, string childName, List<TChild> value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Upsert(childName, value, true)
                .ExecuteAsync();
        }

        /// <summary>
        /// Remove a subdocument from a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> RemoveChildAsync<T>(string key, string childName)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Remove(childName)
                .ExecuteAsync();
        }

        /// <summary>
        /// Inserts an element to the end of an array subdocument by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> InsertArrayChildAsync<T, TChild>(string key, string childName, TChild value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .ArrayAppend(childName, value, true)
                .ExecuteAsync();
        }

        /// <summary>
        /// Replaces an element at a particular index in an array subdocument by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> UpdateArrayChildAsync<T, TChild>(string key, string childName, int index, TChild value)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Replace($"{childName}[{index}]", value)
                .ExecuteAsync();
        }

        /// <summary>
        /// Removes an element at a particular index from an array subdocument by property name
        /// 
        /// NOTE: The limitation with the current Subdocument API is that the array element 
        ///       delete only works with index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IDocumentFragment<T>> RemoveArrayChildAsync<T>(string key, string childName, int index)
        {
            return await _bucket.MutateIn<T>(key.ToLower())
                .Remove($"{childName}[{index}]")
                .ExecuteAsync();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _bucket.Dispose();
        }
    }
}
