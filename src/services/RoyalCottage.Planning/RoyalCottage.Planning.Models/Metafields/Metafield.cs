using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Metafields
{
    public class Metafield
    {
        public int Id { get; set; }
        public string Namespace { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
        public string ValueType { get; set; }
        public object Description { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string OwnerResource { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
