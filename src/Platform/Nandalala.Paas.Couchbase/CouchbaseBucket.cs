using System;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;


namespace Nandalala.Framework.Couchbase
{
    public class CouchbaseBucket : ICouchbaseBucket
    {
        private readonly IBucket _bucket;
        private readonly ICouchbaseClient _couchbaseClient;

        public CouchbaseBucket(ICouchbaseClient couchbaseClient, IBucket bucket)
        {
            _bucket = bucket;
            _couchbaseClient = couchbaseClient;
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
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _bucket.Dispose();
        }
    }
}
