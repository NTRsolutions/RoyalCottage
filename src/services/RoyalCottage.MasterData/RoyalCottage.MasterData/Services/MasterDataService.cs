using RoyalCottage.MasterData.Business.Interfaces;
using RoyalCottage.MasterData.Models;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Framework.Domain;

namespace RoyalCottage.MasterData.Business.Services
{
    public class MasterDataService<T> : EntityService<T>, IMasterDataService<T> where T : CouchbaseTenantEntityBase
    { 
        protected override ICouchbaseRepository<T> Repository { get; }

        public MasterDataService(IMasterDataRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
