using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.Product.Business.Services
{
    public class ProductService : EntityService<ProductDetail>, IProductService
    {
        //private ApplicationContext _appContext;
        protected override ICouchbaseRepository<ProductDetail> Repository { get; }

        public ProductService(IProductRepository repository)
        {
            Repository = repository;
        }
    }
}
