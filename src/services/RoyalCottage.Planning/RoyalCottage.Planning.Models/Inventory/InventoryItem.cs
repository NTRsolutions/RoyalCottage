using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Inventory
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Tracked { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
