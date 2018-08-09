using Nandalala.RoyalCottage.Proxies;
using Nandalala.Paas.Core.Query;
using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class ListAllProducts : QueryBase<IEnumerable<ProductProxy>>
    {}
}
