using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class SmartCollection
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object BodyHtml { get; set; }
        public DateTime PublishedAt { get; set; }
        public string SortOrder { get; set; }
        public object TemplateSuffix { get; set; }
        public bool Disjunctive { get; set; }
        public IList<Rule> Rules { get; set; }
        public string PublishedScope { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
