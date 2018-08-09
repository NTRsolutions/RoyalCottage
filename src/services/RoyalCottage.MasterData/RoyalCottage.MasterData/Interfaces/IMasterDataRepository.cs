using Couchbase.N1QL;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.Couchbase.Repositories;

namespace RoyalCottage.MasterData.Business.Interfaces
{
    public interface IMasterDataRepository<T> : ICouchbaseRepository<T> where T : CouchbaseTenantEntityBase
    {
    }
    public interface IDocumentRepository
    {
        //void InsertDocument(string key, string content);
        //string GetDocument(string key);
        //void UpdateDocument(string key, string content);
        //void RemoveDocument(string key);
        IQueryResult<dynamic> QueryDocuments(IQueryRequest query);
    }
}
