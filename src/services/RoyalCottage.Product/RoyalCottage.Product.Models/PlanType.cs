using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.Product.Models
{
    public class PlanType : CouchbaseTenantEntityBase
    {
        #region properties
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public PlanType() : base(TypeConstants.PlanType, Guid.Empty, Guid.NewGuid()) { }

        public PlanType(Guid tenantId) : base(TypeConstants.PlanType, tenantId, Guid.NewGuid()) { }
        public PlanType(Guid tenantId, Guid id) : base(TypeConstants.PlanType, tenantId, id) { }
        #endregion
    }
}
