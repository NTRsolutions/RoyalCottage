using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Proxies
{
    public class ListProductTypesResponse
    {
        public IEnumerable<ProductTypeProxy> Products { get; set; }
    }
}
