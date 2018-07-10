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
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanTypeService, PlanTypeService>();
            services.AddScoped<IPlanTypeRepository, PlanTypeRepository>();
        }
    }
}
