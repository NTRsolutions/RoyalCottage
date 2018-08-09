using Newtonsoft.Json;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.RoyalCottage.Proxies;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Query;
using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class ListProductsHandler : IQueryHandler<ListProducts, IEnumerable<ProductProxy>>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public ListProductsHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        public IEnumerable<ProductProxy> Handle(ListProducts query)
        {
            var result = _repository.GetDocument(query.ProductId.ToString());
            ProductProxy Product = JsonConvert.DeserializeObject<ProductProxy>(result);
            return new List<ProductProxy> { Product };
        }

        
    }
}
