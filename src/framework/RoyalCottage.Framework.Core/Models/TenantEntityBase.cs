using System;

namespace RoyalCottage.Framework.Core.Models
{
    public abstract class TenantEntityBase : DomainEntityBase
    {
        #region properties
        public Guid TenantId { get; set; }
        #endregion

        #region ctor
        public TenantEntityBase(Guid tenantId, Guid id) : base(id)
        {
            TenantId = tenantId;
        }
        #endregion
    }
}
