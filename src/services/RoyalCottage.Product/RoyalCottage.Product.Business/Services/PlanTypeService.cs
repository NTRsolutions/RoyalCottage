using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.Product.Business.Services
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
