using System;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.N1QL;

namespace Nandalala.Framework.Couchbase
{
    /// <summary>
    /// IBucketClient client
    /// </summary>
    public interface ICouchbaseBucket : IDisposable
    {
        /// <summary>
        /// Gets the and lock asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="expiration">The expiration.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> GetAndLockAsync<T>(string key, TimeSpan expiration);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> InsertAsync<T>(string key, T value);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> InsertAsync<T>(string key, T value, TimeSpan expiration);
        /// <summary>
        /// Upserts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> UpsertAsync<T>(string key, T value);

        /// <summary>
        /// Upserts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiration">The expiration.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> UpsertAsync<T>(string key, T value, TimeSpan expiration);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<IOperationResult> RemoveAsync(string key);

        /// <summary>
        /// Gets the by key asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<IOperationResult<T>> GetAsync<T>(string key);

        /// <summary>
        /// Queries the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        Task<IQueryResult<T>> QueryAsync<T>(IQueryRequest query);
    }
}
