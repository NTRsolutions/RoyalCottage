using Microsoft.Extensions.DependencyInjection;
using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Business.Repositories;
using RoyalCottage.Product.Business.Services;

namespace RoyalCottage.Product.Business
{
    public static class ServicesConfiguration
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        }
    }
}
