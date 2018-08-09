using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.MasterData.Models
{
    public class ProficiencyLevel : CouchbaseTenantEntityBase
    {
        #region properties
        public string Value { get; set; }
        #endregion

        #region 
        //Below constructor is just for auto-initiation
        public ProficiencyLevel() : base(TypeConstants.ProficiencyLevel, Guid.Empty, Guid.NewGuid()) { }
        public ProficiencyLevel(Guid tenantId) : base(TypeConstants.ProficiencyLevel, tenantId, Guid.NewGuid()) { }
        public ProficiencyLevel(Guid tenantId, Guid id) : base(TypeConstants.ProficiencyLevel, tenantId, id) { }
        #endregion
    }
}
