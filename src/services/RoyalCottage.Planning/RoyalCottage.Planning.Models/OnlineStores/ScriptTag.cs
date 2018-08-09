using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.OnlineStores
{
    public class ScriptTag
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Event { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DisplayScope { get; set; }
    }

}
