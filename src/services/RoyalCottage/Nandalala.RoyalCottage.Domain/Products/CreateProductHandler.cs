using Newtonsoft.Json;
using Nandalala.RoyalCottage.Data.Models;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Command;
using System;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public CreateProductHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        public void Handle(CreateProduct command)
        {
            var Product = new Product(_securityContext.TenantId, Guid.NewGuid())
            {
                Name = command.Name,
                Description = command.Description,
                ProductTypeId = command.ProductTypeId,
                CreatedBy = _securityContext.EntityId,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = _securityContext.EntityId,
                LastUpdatedOn = DateTime.Now
            };

            try
            {
                _repository.InsertDocument(Product.EntityId.ToString(), JsonConvert.SerializeObject(Product));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
