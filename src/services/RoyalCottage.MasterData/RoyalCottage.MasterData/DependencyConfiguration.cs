using Microsoft.Extensions.DependencyInjection;
using RoyalCottage.MasterData.Business.Interfaces;
using RoyalCottage.MasterData.Business.Repositories;
using RoyalCottage.MasterData.Business.Services;

namespace RoyalCottage.MasterData.Business
{
    public static class ServicesConfiguration
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMasterDataService<>), typeof(MasterDataService<>));
            services.AddScoped(typeof(IMasterDataRepository<>), typeof(MasterDataRepository<>));
        }
    }
}
