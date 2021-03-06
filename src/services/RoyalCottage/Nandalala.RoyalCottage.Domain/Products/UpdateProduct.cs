﻿using Nandalala.Paas.Core.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nandalala.RoyalCottage.Domain.Products
{
    public class UpdateProduct : CommandBase
    {
        [Required(ErrorMessage = "Product id is required")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Product type is required")]
        public Guid ProductTypeId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
