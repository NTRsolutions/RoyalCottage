using RoyalCottage.Planning.Models;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Planning.Business.Interfaces
{
    public interface IPlanRepository : ICouchbaseRepository<Plan>
    {
    }
}
