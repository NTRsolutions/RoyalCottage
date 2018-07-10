using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Threading.Tasks;
using Couchbase.N1QL;
using RoyalCottage.Framework.Core.Models;
using System.Collections.Generic;

namespace RoyalCottage.Framework.Couchbase.Repositories
{
    public interface ICouchbaseRepository<T>
        where T : CouchbaseTenantEntityBase
    {
        #region Document Operations
        Task<BusinessResponse<T>> GetAsync(string key);
        Task<BusinessResponse<T>> GetAllAsync(Guid tenantId, Guid typeId);
        Task<BusinessResponse<T>> InsertAsync(T data);
        Task<BusinessResponse<T>> UpdateAsync(T data);
        Task<BusinessResponse<T>> SoftRemoveAsync(string key);
        Task<BusinessResponse<T>> RemoveAsync(string key);
        Task<BusinessResponse<T>> GetAsync(IQueryRequest query);
        #endregion

        #region Sub-Document Operations
        Task<BusinessResponse<TChild>> GetChildAsync<TChild>(string key, string childName, bool isCollection = false) where TChild : EntityBase;
        Task<BusinessResponse<T>> InsertChildAsync<TChild>(string key, string childName, TChild data, bool isCollection = false) where TChild : EntityBase;
        Task<BusinessResponse<T>> InsertChildAsync<TChild>(string key, string childName, List<TChild> data) where TChild : EntityBase;
        Task<BusinessResponse<T>> UpdateChildAsync<TChild>(string key, string childName, TChild data, bool isCollection = false) where TChild : EntityBase;
        Task<BusinessResponse<T>> UpdateChildAsync<TChild>(string key, string childName, List<TChild> data) where TChild : EntityBase;
        Task<BusinessResponse<T>> RemoveChildAsync<TChild>(string key, string childName, bool isCollection = false, Guid childId = default(Guid)) where TChild : EntityBase;
        #endregion
    }
}
