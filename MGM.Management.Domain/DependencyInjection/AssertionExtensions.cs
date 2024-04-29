using MGM.Management.Domain.Assertions;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Management.Domain.DependencyInjection
{
    public static class AssertionExtensions
    {
        public static IServiceCollection AddAssertions(this IServiceCollection services)
        {
            services.AddSingleton<IMotoAssertion, MotoAssertion>();
            services.AddSingleton<IUserAssertion, UserAssertion>();
            services.AddSingleton<IRentalPlanUserAssertion, RentalPlanUserAssertion>();

            return services;
        }
    }
}
