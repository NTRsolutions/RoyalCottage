using Newtonsoft.Json;
using Nandalala.RoyalCottage.Data.Models;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Command;
using System;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public UpdateProductHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        public void Handle(UpdateProduct command)
        {
            try
            {
                
                var result = _repository.GetDocument(command.ProductId.ToString());
                var Product = JsonConvert.DeserializeObject<Product>(result);
                Product.Name = command.Name;
                Product.Description = command.Description;
                Product.ProductTypeId = command.ProductTypeId;
                Product.LastUpdatedOn = DateTime.Now;
                Product.LastUpdatedBy = _securityContext.EntityId;

                _repository.UpdateDocument(command.ProductId.ToString(), JsonConvert.SerializeObject(Product));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
