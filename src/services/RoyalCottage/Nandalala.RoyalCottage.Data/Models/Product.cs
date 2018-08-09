using Newtonsoft.Json;
using Nandalala.Paas.Core;
using System;

namespace Nandalala.RoyalCottage.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Product : EntityTenant
    {
        public Product(Guid tenantId, Guid entityId) : base(tenantId, entityId)
        {
           
             TypeId = EntityContext.Product;
        }

        [JsonProperty]
        public Guid ProductTypeId { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public Guid CreatedBy { get; set; }
        [JsonProperty]
        public DateTime CreatedOn { get; set; }
        [JsonProperty]
        public Guid LastUpdatedBy { get; set; }
        [JsonProperty]
        public DateTime LastUpdatedOn { get; set; }
        
    }
}
