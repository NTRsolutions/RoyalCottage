using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class Asset
    {
        public string Key { get; set; }
        public string PublicUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ContentType { get; set; }
        public int Size { get; set; }
        public int ThemeId { get; set; }
    }

}
