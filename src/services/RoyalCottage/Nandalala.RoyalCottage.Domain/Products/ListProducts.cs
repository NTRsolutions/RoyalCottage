using Nandalala.RoyalCottage.Proxies;
using Nandalala.Paas.Core.Query;
using System;
using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class ListProducts : QueryBase<IEnumerable<ProductProxy>>
    {
        public Guid ProductId { get; set; }
    }
}
