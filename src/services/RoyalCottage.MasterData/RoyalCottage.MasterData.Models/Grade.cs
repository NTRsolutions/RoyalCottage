using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.MasterData.Models
{
    public class Grade : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Grade() : base(TypeConstants.Grade, Guid.Empty, Guid.NewGuid()) { }

        public Grade(Guid tenantId) : base(TypeConstants.Grade, tenantId, Guid.NewGuid()) { }
        public Grade(Guid tenantId, Guid id) : base(TypeConstants.Grade, tenantId, id) { }
        #endregion
    }
}
