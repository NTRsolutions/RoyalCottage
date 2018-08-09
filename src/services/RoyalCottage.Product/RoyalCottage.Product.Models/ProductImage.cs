using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object Alt { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Src { get; set; }
        public IList<int> VariantIds { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
