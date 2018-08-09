using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BodyHtml { get; set; }
        public int BlogId { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object SummaryHtml { get; set; }
        public object TemplateSuffix { get; set; }
        public string Handle { get; set; }
        public string Tags { get; set; }
        public string AdminGraphqlApiId { get; set; }
        public Image Image { get; set; }
    }
}
