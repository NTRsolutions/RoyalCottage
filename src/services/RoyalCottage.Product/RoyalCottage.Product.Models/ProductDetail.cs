using RoyalCottage.Framework.Couchbase.Models;
using System;
using System.Collections.Generic;

namespace RoyalCottage.Product.Models
{
    public class ProductDetail : CouchbaseTenantEntityBase
    {
        #region properties
        public int id { get; set; }
        public int date { get; set; }
        public string name { get; set; }
        public string description { get; set; }


        public int price { get; set; }
        public int priceNormal { get; set; }
        public int reduction { get; set; }
        public string imageURLs { get; set; }
        public string imageRefs { get; set; }
        public List<Category> categories { get; set; }
        public List<Rating> ratings { get; set; }
        public int currentRating { get; set; }
        public bool sale { get; set; }
        

        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public ProductDetail() : base(Guid.NewGuid(), Guid.Empty, Guid.NewGuid()) { }
        public ProductDetail(Guid tenantId) : base(Guid.NewGuid(), tenantId, Guid.NewGuid()) { }
        public ProductDetail(Guid tenantId, Guid id) : base(TypeConstants.ProductDetail, tenantId, id) { }
        #endregion
    }
}
