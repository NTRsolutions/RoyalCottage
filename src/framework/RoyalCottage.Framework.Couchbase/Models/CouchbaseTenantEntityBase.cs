using Newtonsoft.Json;
using RoyalCottage.Framework.Core.Models;
using System;

namespace RoyalCottage.Framework.Couchbase.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class CouchbaseTenantEntityBase : TenantEntityBase
    {
        #region properties
        /// <summary>
        /// Identifies the type of the entity in Couchbase.
        /// </summary>
        public Guid TypeId { get; }  
        /// <summary>
        /// This property will be used as the Key for creating this entity in Couchbase.
        /// Building the data partitioning by type and tenant, right at the key level.
        /// </summary>
        [JsonIgnore]
        public string Key { get { return $"{ TypeId.ToString()}_{TenantId.ToString()}_{Id.ToString()}"; } }
        #endregion

        #region ctor
        public CouchbaseTenantEntityBase(Guid typeId, Guid tenantId, Guid id) : base (tenantId, id)
        {
            TypeId = typeId;
        }
        #endregion

    }
}
