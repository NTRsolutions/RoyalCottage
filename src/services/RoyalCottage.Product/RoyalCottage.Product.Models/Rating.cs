using Newtonsoft.Json;
using RoyalCottage.Framework.Couchbase.Models;
using System;

namespace RoyalCottage.Product.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Rating : CouchbaseTenantEntityBase
    {
        #region properties
        public string UserUid { get; set; }
        public int rating { get; set; }
        #endregion

        #region ctor
        //Below constructor is just for auto-initiation
        public Rating() : base(TypeConstants.Rating, Guid.Empty, Guid.NewGuid()) { }

        public Rating(Guid tenantId) : base(TypeConstants.Rating, tenantId, Guid.NewGuid()) { }
        public Rating(Guid tenantId, Guid id) : base(TypeConstants.Rating, tenantId, id) { }
        #endregion
    }
}
