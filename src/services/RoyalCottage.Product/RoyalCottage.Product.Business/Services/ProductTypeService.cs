using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.Product.Business.Services
{
    public class ProductTypeService : EntityService<ProductType>, IProductTypeService
    {
        //private ApplicationContext _appContext;
        protected override ICouchbaseRepository<ProductType> Repository { get; }

        public ProductTypeService(IProductTypeRepository repository)
        {
            Repository = repository;
        }
    }
}
