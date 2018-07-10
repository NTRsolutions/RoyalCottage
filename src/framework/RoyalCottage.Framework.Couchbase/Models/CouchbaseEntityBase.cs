using RoyalCottage.Framework.Core.Models;
using System;

namespace RoyalCottage.Framework.Couchbase.Models
{
    /// <summary>
    /// Base type for all Couchbase entities which are NOT specific to any tenant.
    /// All Tenant-independant entities should inherit from this type.
    /// </summary>
    /// <typeparam name="TKey">Type of the Id property</typeparam>
    public abstract class CouchbaseEntityBase : DomainEntityBase
    {
        #region ctor
        public CouchbaseEntityBase(Guid typeId, Guid id) : base(id)
        {
            TypeId = typeId;
        }
        #endregion

        #region properties
        /// <summary>
        /// Identifies the type of the entity in Couchbase.
        /// </summary>
        public Guid TypeId { get; }
        /// <summary>
        /// This property will be used as the Key for creating this entity in Couchbase.
        /// Building the data partitioning by type, right at the key level.
        /// </summary>
        public string Key { get { return $"{ TypeId.ToString()}_{Id.ToString()}"; } }
        #endregion
    }
}
