using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Proxies
{
    public class ListProductsResponse
    {
        public IEnumerable<ProductProxy> Products { get; set; }
    }
}
