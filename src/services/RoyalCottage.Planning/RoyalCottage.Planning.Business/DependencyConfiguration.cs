using Microsoft.Extensions.DependencyInjection;
using RoyalCottage.Planning.Business.Interfaces;
using RoyalCottage.Planning.Business.Repositories;
using RoyalCottage.Planning.Business.Services;

namespace RoyalCottage.Planning.Business
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
