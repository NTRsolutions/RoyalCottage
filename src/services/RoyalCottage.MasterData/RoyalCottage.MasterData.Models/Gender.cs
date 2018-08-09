using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.MasterData.Models
{
    public class Gender : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Gender() : base(TypeConstants.Company, Guid.Empty, Guid.NewGuid()) { }

        public Gender(Guid tenantId) : base(TypeConstants.Gender, tenantId, Guid.NewGuid()) { }
        public Gender(Guid tenantId, Guid id) : base(TypeConstants.Gender, tenantId, id) { }
        #endregion
    }
}
