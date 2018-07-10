using RoyalCottage.Planning.Business.Interfaces;
using RoyalCottage.Planning.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.Planning.Business.Services
{
    public class PlanTypeService : EntityService<PlanType>, IPlanTypeService
    {
        //private ApplicationContext _appContext;
        protected override ICouchbaseRepository<PlanType> Repository { get; }

        public PlanTypeService(IPlanTypeRepository repository)
        {
            Repository = repository;
        }
    }
}
