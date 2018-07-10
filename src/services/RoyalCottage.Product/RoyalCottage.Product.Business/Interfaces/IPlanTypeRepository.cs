using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Product.Business.Interfaces
{
    public interface IPlanTypeRepository : ICouchbaseRepository<PlanType>
    {

    }
}
