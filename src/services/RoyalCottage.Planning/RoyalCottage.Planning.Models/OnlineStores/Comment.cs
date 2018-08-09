using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string BodyHtml { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int ArticleId { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public object PublishedAt { get; set; }
    }
}
