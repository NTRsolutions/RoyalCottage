using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Product.Business.Repositories
{
    public class PlanTypeRepository : CouchbaseRepository<PlanType>, IPlanTypeRepository
    {
        public PlanTypeRepository(ICouchbaseBucket bucket) : base(bucket)
        {

        }
    }
}
