using Newtonsoft.Json;
using Nandalala.RoyalCottage.Data.Models;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Command;
using System;

namespace Nandalala.RoyalCottage.Domain.ProductTypes
{
    public class CreateProductTypeHandler : ICommandHandler<CreateProductType>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public CreateProductTypeHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }
        public void Handle(CreateProductType command)
        {
            var ProductType = new ProductType(_securityContext.TenantId, Guid.NewGuid())
            {
                Name = command.Name,
                Description = command.Description,
                CreatedBy = _securityContext.EntityId,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = _securityContext.EntityId,
                LastUpdatedOn = DateTime.Now
            };

            try
            {
                _repository.InsertDocument(ProductType.EntityId.ToString(), JsonConvert.SerializeObject(ProductType));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
