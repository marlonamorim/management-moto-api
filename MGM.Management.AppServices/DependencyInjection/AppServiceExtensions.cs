using MGM.Management.AppServices.Service.Persistence;
using MGM.Management.AppServices.Service.Search;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Management.AppServices.DependencyInjection
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IUpsertMotoAppService, UpsertMotoAppService>();
            services.AddSingleton<IDeleteMotoAppService, DeleteMotoAppService>();
            services.AddSingleton<IGetMotoAppService, GetMotoAppService>();
            services.AddSingleton<IUpsertUserAppService, UpsertUserAppService>();
            services.AddSingleton<IGetRentalPlanAppService, GetRentalPlanAppService>();
            services.AddSingleton<ICreateRentalPlanUserAppService, CreateRentalPlanUserAppService>();
            services.AddSingleton<IGetQuotationRentalPlanAppService, GetQuotationRentalPlanAppService>();
            return services;
        }
    }
}
