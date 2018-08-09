using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.Product.Business.Repositories
{
    public class ProductTypeRepository : CouchbaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ICouchbaseBucket bucket) : base(bucket)
        {

        }
    }
}
