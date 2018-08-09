using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class Level : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Level() : base(TypeConstants.Level, Guid.Empty, Guid.NewGuid()) { }
        public Level(Guid tenantId) : base(TypeConstants.Level, tenantId, Guid.NewGuid()) { }
        public Level(Guid tenantId, Guid id) : base(TypeConstants.Level, tenantId, id) { }
        #endregion
    }
}
