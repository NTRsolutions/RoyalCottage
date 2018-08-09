using Nandalala.Paas.Core.Command;
using System.ComponentModel.DataAnnotations;

namespace Nandalala.RoyalCottage.Domain.ProductTypes
{
    public class CreateProductType : CommandBase
    {
        [Required(ErrorMessage = "Product type is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
