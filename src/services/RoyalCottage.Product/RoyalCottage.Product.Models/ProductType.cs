using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.Product.Models
{
    public class ProductType : CouchbaseTenantEntityBase
    {
        #region properties
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public ProductType() : base(TypeConstants.ProductType, Guid.Empty, Guid.NewGuid()) { }

        public ProductType(Guid tenantId) : base(Guid.NewGuid(), tenantId, Guid.NewGuid()) { }
        public ProductType(Guid tenantId, Guid id) : base(TypeConstants.ProductType, tenantId, id) { }
        #endregion
    }
}
