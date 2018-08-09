using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ShopId { get; set; }
        public string Handle { get; set; }
        public string BodyHtml { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public object TemplateSuffix { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
