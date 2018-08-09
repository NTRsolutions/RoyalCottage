using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.Product.Models
{
    public class Category : CouchbaseTenantEntityBase
    {
        #region properties
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public Category() : base(TypeConstants.Category, Guid.Empty, Guid.NewGuid()) { }

        public Category(Guid tenantId) : base(TypeConstants.Category, tenantId, Guid.NewGuid()) { }
        public Category(Guid tenantId, Guid id) : base(TypeConstants.Category, tenantId, id) { }
        #endregion
    }
}
