using MGM.Management.Moto.Infrastructure.DataSettings;
using MGM.Management.Moto.Infrastructure.Repositories;
using MGM.Management.Moto.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Management.Moto.Infrastructure.DependencyInjection
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MotoStoreDatabaseSettings>(
                configuration.GetSection("MotoStoreDatabase"));

            services.AddSingleton<IMotoRepository, MotoRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRentalPlanRepository, RentalPlanRepository>();
            services.AddSingleton<IRentalPlanUserRepository, RentalPlanUserRepository>();

            return services;
        }
    }
}
