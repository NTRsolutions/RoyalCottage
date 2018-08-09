using RoyalCottage.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class ProductProductType : EntityBase
    {
        public ProductProductType(Guid key) : base(key) {}

        public string Name { get; set; }
    }
}
