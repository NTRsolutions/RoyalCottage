using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool AcceptsMarketing { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrdersCount { get; set; }
        public string State { get; set; }
        public string TotalSpent { get; set; }
        public int LastOrderId { get; set; }
        public object Note { get; set; }
        public bool VerifiedEmail { get; set; }
        public object MultipassIdentifier { get; set; }
        public bool TaxExempt { get; set; }
        public object Phone { get; set; }
        public string Tags { get; set; }
        public string LastOrderName { get; set; }
        public IList<Address> Addresses { get; set; }
        public string AdminGraphqlApiId { get; set; }
        public Address DefaultAddress { get; set; }
    }
}
