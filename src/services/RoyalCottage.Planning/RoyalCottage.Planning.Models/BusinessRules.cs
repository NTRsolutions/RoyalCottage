using RoyalCottage.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models
{
    public class BusinessRules : EntityBase
    {
        public BusinessRules(Guid key) : base(key) { }

        public string Cat { get; set; }
        public string CbfLevel { get; set; }
        public string CbfRole { get; set; }
        public string Grade { get; set; }
        public string Hcc { get; set; }
        public Guid Plan { get; set; }
        public string Value { get; set; }
    }
}
