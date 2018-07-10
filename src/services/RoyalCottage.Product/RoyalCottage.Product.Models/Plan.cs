using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;

namespace RoyalCottage.Product.Models
{
    public class Plan : CouchbaseTenantEntityBase
    {
        #region properties
        public PlanPlanType PlanType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ExcludedEmployee> ExcludedEmployees { get; set; }
        public List<BusinessRules> BusinessRules { get; set; }
        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public Plan() : base(TypeConstants.Plan, Guid.Empty, Guid.NewGuid()) { }
        public Plan(Guid tenantId) : base(TypeConstants.Plan, tenantId, Guid.NewGuid()) { }
        public Plan(Guid tenantId, Guid id) : base(TypeConstants.Plan, tenantId, id) { }
        #endregion
    }
}
