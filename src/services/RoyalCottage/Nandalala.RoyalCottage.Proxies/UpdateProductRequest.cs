using System;

namespace Nandalala.RoyalCottage.Proxies
{
    public class UpdateProductRequest
    {
        public string entityId { get; set; }
        public string ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
