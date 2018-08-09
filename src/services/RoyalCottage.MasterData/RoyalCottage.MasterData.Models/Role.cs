using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class Role : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Role() : base(TypeConstants.Role, Guid.Empty, Guid.NewGuid()) { }
        public Role(Guid tenantId) : base(TypeConstants.Role, tenantId, Guid.NewGuid()) { }
        public Role(Guid tenantId, Guid id) : base(TypeConstants.Role, tenantId, id) { }
        #endregion
    }
}
