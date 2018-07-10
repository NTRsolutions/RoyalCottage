using RoyalCottage.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class PlanPlanType : EntityBase
    {
        public PlanPlanType(Guid key) : base(key) {}

        public string Name { get; set; }
    }
}
