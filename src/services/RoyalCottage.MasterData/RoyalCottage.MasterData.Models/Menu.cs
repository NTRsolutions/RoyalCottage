using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.MasterData.Models
{
    public class Menu : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public Menu() : base(TypeConstants.Menu, Guid.Empty, Guid.NewGuid()) { }

        public Menu(Guid tenantId) : base(TypeConstants.Menu, tenantId, Guid.NewGuid()) { }
        public Menu(Guid tenantId, Guid id) : base(TypeConstants.Menu, tenantId, id) { }
        #endregion
    }
}
