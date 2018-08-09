using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class Status : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Status() : base(TypeConstants.Status, Guid.Empty, Guid.NewGuid()) { }
        public Status(Guid tenantId) : base(TypeConstants.Status, tenantId, Guid.NewGuid()) { }
        public Status(Guid tenantId, Guid id) : base(TypeConstants.Status, tenantId, id) { }
        #endregion
    }
}
