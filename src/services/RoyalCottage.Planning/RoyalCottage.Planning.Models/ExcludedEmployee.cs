using RoyalCottage.Framework.Core.Models;
using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models
{
    public class ExcludedEmployee : EntityBase
    {
        public ExcludedEmployee(Guid key) : base(key) { }

        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    }
}