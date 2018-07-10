using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.N1QL;

namespace RoyalCottage.Framework.Couchbase
{
    /// <summary>
    /// IBucketClient client
    /// </summary>
    public interface ICouchbaseBucket : IDisposable
    {
        string BucketName { get; }

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

        /// <summary>
        /// Insert a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> InsertChildAsync<T, TChild>(string key, string childName, TChild value);

        /// <summary>
        /// Insert a collection subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> InsertArrayChildAsync<T, TChild>(string key, string childName, List<TChild> value);

        /// <summary>
        /// Gets a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> GetChildAsync<T>(string key, string childName);

        /// <summary>
        /// Insert or Update a subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> UpsertChildAsync<T, TChild>(string key, string childName, TChild value);

        /// <summary>
        /// Insert or Update a Collection subdocument for a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> UpsertChildAsync<T, TChild>(string key, string childName, List<TChild> value);

        /// <summary>
        /// Remove a subdocument from a document by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> RemoveChildAsync<T>(string key, string childName);

        /// <summary>
        /// Inserts an element to the end of an array subdocument by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> InsertArrayChildAsync<T, TChild>(string key, string childName, TChild value);

        /// <summary>
        /// Replaces an element at a particular index in an array subdocument by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> UpdateArrayChildAsync<T, TChild>(string key, string childName, int index, TChild value);

        /// <summary>
        /// Removes an element at a particular index from an array subdocument by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="childName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IDocumentFragment<T>> RemoveArrayChildAsync<T>(string key, string childName, int index);
    }
}
