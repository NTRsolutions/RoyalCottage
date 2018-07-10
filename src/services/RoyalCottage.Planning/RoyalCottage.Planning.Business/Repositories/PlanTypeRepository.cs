using RoyalCottage.Planning.Business.Interfaces;
using RoyalCottage.Planning.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Planning.Business.Repositories
{
    public class PlanTypeRepository : CouchbaseRepository<PlanType>, IPlanTypeRepository
    {
        public PlanTypeRepository(ICouchbaseBucket bucket) : base(bucket)
        {

        }
    }
}
