using Nandalala.Paas.Core.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class DeleteProduct : CommandBase
    {
        [Required(ErrorMessage = "Product id is required")]
        public Guid ProductId { get; set; }
    }
}
