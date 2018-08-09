using Couchbase.N1QL;
using Nandalala.Framework.Couchbase;

namespace Nandalala.RoyalCottage.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ICouchbaseBucket _bucket;
        
        public DocumentRepository(ICouchbaseBucket bucket)
        {
            _bucket = bucket;
        }

        public string GetDocument(string key)
        {
            var result = _bucket.GetAsync<string>(key);
            return result.Result.Value;
        }

        public void InsertDocument(string key, string content)
        {
            var result = _bucket.InsertAsync(key, content);
            
        }

        public void UpdateDocument(string key, string content)
        {
            var result = _bucket.UpsertAsync(key, content);
            
        }

        public void RemoveDocument(string key)
        {
            var result = _bucket.RemoveAsync(key);
            
        }
        
        public IQueryResult<dynamic> QueryDocuments(IQueryRequest query)
        {
            return  _bucket.QueryAsync<dynamic>(query).Result;
            

        }


    }
}
