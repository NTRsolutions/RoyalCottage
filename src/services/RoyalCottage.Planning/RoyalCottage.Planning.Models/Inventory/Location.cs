using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Inventory
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public object Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public object Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ProvinceCode { get; set; }
        public bool Legacy { get; set; }
        public string AdminGraphqlApiId { get; set; }
    }

}
