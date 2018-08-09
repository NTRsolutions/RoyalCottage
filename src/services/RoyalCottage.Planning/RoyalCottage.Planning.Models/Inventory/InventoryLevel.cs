using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Inventory
{
    public class InventoryLevel
    {
        public int InventoryItemId { get; set; }
        public int LocationId { get; set; }
        public int Available { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
