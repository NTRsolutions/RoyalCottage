using RoyalCottage.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoyalCottage.Framework.Domain.Interfaces
{
    public interface IEntityService<T>
        where T : DomainEntityBase
    {
        Task<BusinessResponse<T>> GetAsync<TKey>(Guid tenantId, TKey id);
        Task<BusinessResponse<T>> GetAllAsync(Guid tenantId);
        Task<BusinessResponse<T>> CreateAsync(T data);
        Task<BusinessResponse<T>> UpdateAsync(T data);
        Task<BusinessResponse<T>> DeleteAsync<TKey>(Guid tenantId, TKey id);
        Task<BusinessResponse<TChild>> GetChildAsync<TKey, TChild>(Guid tenantId, TKey id, string childName) where TChild : EntityBase;
        Task<BusinessResponse<TChild>> GetChildAllAsync<TKey, TChild>(Guid tenantId, TKey id, string childName) where TChild : EntityBase;

        /// <summary>
        /// Add a new child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> CreateChildAsync<TChild>(Guid tenantId, Guid id, string childName, TChild data) where TChild : EntityBase;

        /// <summary>
        /// Add a new collection child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> CreateChildAsync<TChild>(Guid tenantId, Guid id, string childName, List<TChild> data) where TChild : EntityBase;
        
        /// <summary>
        /// Add a new value to a Collection Child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> CreateCollectionChildAsync<TChild>(Guid tenantId, Guid id, string childName, TChild data) where TChild : EntityBase;

        /// <summary>
        /// Update a collection child element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> UpdateChildAsync<TChild>(Guid tenantId, Guid id, string childName, List<TChild> data) where TChild : EntityBase;

        /// <summary>
        /// Delete a Child Element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> DeleteChildAsync<TChild>(Guid tenantId, Guid id, string childName) where TChild : EntityBase;

        /// <summary>
        /// Delete a value from a Collection Child Element
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="tenantId"></param>
        /// <param name="id"></param>
        /// <param name="childName"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        Task<BusinessResponse<T>> DeleteCollectionChildAsync<TChild>(Guid tenantId, Guid id, string childName, Guid childId) where TChild : EntityBase;
    }
}
