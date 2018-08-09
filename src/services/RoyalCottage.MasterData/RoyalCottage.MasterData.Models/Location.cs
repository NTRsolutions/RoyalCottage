using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class Location : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Location() : base(TypeConstants.Location, Guid.Empty, Guid.NewGuid()) { }
        public Location(Guid tenantId) : base(TypeConstants.Location, tenantId, Guid.NewGuid()) { }
        public Location(Guid tenantId, Guid id) : base(TypeConstants.Location, tenantId, id) { }
        #endregion
    }
}
