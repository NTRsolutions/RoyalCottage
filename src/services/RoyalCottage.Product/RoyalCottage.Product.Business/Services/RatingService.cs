using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.Product.Business.Services
{
    public class RatingService : EntityService<Rating>, IRatingService
    {
        //private ApplicationContext _appContext;
        protected override ICouchbaseRepository<Rating> Repository { get; }

        public RatingService(IRatingRepository repository)
        {
            Repository = repository;
        }
    }
}
