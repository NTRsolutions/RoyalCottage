using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.Paas.Core;
using Nandalala.Paas.Core.Command;
using System;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly IDocumentRepository _repository;
        private readonly SecurityContext _securityContext;

        public DeleteProductHandler(SecurityContext securityContext, IDocumentRepository repository)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        public void Handle(DeleteProduct command)
        {
            try
            {
                _repository.RemoveDocument(command.ProductId.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
