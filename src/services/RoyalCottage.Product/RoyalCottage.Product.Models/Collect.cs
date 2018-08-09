using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class Collect
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int ProductId { get; set; }
        public bool Featured { get; set; }
        public object CreatedAt { get; set; }
        public object UpdatedAt { get; set; }
        public int Position { get; set; }
        public string SortValue { get; set; }
    }
}
