using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Role { get; set; }
        public int? ThemeStoreId { get; set; }
        public bool Previewable { get; set; }
        public bool Processing { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }
}
