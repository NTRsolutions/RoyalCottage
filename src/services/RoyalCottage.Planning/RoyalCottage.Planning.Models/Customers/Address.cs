using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Customers
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public object FirstName { get; set; }
        public object LastName { get; set; }
        public object Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string ProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool Default { get; set; }
    }
}
