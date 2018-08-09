using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Product.Business.Repositories
{
    public class RatingRepository : CouchbaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ICouchbaseBucket bucket) : base(bucket)
        {

        }
    }
}
