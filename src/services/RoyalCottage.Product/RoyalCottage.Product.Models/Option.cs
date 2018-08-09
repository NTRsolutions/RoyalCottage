using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Product.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public IList<string> Values { get; set; }
    }
}
