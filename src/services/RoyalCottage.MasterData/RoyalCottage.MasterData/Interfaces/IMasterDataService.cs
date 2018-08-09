using RoyalCottage.Framework.Core.Models;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.Domain.Interfaces;

namespace RoyalCottage.MasterData.Business.Interfaces
{
    public interface IMasterDataService<T> : IEntityService<T> where T : CouchbaseTenantEntityBase
    {
        
    }
}
