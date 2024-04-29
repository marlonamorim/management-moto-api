using MGM.Management.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Management.Domain.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IContextAccessorService, ContextAccessorService>();
            services.AddSingleton<IQuotationService, QuotationService>();

            return services;
        }
    }
}
