using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Events
{
    public class Webhook
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Format { get; set; }
        public IList<object> Fields { get; set; }
        public IList<object> MetafieldNamespaces { get; set; }
    }
}
