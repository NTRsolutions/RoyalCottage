using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class MenuItem : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public MenuItem() : base(TypeConstants.MenuItem, Guid.Empty, Guid.NewGuid()) { }
        public MenuItem(Guid tenantId) : base(TypeConstants.MenuItem, tenantId, Guid.NewGuid()) { }
        public MenuItem(Guid tenantId, Guid id) : base(TypeConstants.MenuItem, tenantId, id) { }
        #endregion
    }
}
