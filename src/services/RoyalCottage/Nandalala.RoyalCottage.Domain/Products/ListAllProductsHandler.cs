using Couchbase.N1QL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nandalala.RoyalCottage.Data.Models;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.RoyalCottage.Proxies;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class ListAllProductsHandler : IQueryHandler<ListAllProducts, IEnumerable<ProductProxy>>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public ListAllProductsHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }



        public IEnumerable<ProductProxy> Handle(ListAllProducts query)
        {

            List<ProductProxy> Products = new List<ProductProxy>();
            var nquery = "SELECT EntityId,ProductTypeId, Name, Description, CreatedBy,CreatedOn from Product Where TenantId ='" +
                _securityContext.TenantId.ToString() + "' AND EntityTypeId='" +
                EntityContext.Plan.ToString() + "'";


            var request = new QueryRequest(nquery);
            var result = _repository.QueryDocuments(request);

            foreach (var row in result.Rows)
            {
                Products.Add(JsonConvert.DeserializeObject<ProductProxy>(JsonConvert.SerializeObject(row)));
            }
            return Products;
        }

        IEnumerable<ProductProxy> IQueryHandler<ListAllProducts, IEnumerable<ProductProxy>>.Handle(ListAllProducts query)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
