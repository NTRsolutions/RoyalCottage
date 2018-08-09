using Couchbase.N1QL;
using System.Threading.Tasks;

namespace Nandalala.RoyalCottage.Data.Repositories
{
    public interface IDocumentRepository
    {
        void InsertDocument(string key, string content);
        string GetDocument(string key);
        void UpdateDocument(string key, string content);
        void RemoveDocument(string key);
        IQueryResult<dynamic> QueryDocuments(IQueryRequest query);
        
    }
}
