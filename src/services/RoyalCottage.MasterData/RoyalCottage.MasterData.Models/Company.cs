using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.MasterData.Models
{
    public class Company : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Company() : base(TypeConstants.Company, Guid.Empty, Guid.NewGuid()) { }

        public Company(Guid tenantId) : base(TypeConstants.Company, tenantId, Guid.NewGuid()) { }
        public Company(Guid tenantId, Guid id) : base(TypeConstants.Company, tenantId, id) { }
        #endregion
    }
}
