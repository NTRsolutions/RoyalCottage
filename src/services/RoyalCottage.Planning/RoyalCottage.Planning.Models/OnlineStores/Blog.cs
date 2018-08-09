using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Blog
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Commentable { get; set; }
        public object Feedburner { get; set; }
        public object FeedburnerLocation { get; set; }
        public DateTime CreatedAt { get; set; }
        public object TemplateSuffix { get; set; }
        public string Tags { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
