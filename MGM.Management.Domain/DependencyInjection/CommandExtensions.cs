using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Command.Search;
using MGM.Management.Domain.Handler;
using MGM.Management.Domain.Handler.Persistence;
using MGM.Management.Domain.Handler.Search;
using MGM.Management.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Management.Domain.DependencyInjection
{
    public static class CommandExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services) {

            services.AddSingleton<ICreatedMotoCommand, CreatedMotoCommand>();
            services.AddSingleton<IUpdateMotoCommand, UpdateMotoCommand>();
            services.AddSingleton<IDeleteMotoCommand, DeleteMotoCommand>();
            services.AddSingleton<IGetByLicensePlateMotoCommand, GetByLicensePlateMotoCommand>();
            services.AddSingleton<IListAllMotoCommand, ListAllMotoCommand>();
            services.AddSingleton<ICreatedUserCommand, CreatedUserCommand>();
            services.AddSingleton<IUpdateUserCommand, UpdateUserCommand>();
            services.AddSingleton<ICreateRentalPlanUserCommand, CreateRentalPlanUserCommand>();
            services.AddSingleton<IListAllRentalPlanCommand, ListAllRentalPlanCommand>();
            services.AddSingleton<IPersistenceHandler<ICreatedMotoCommand>, MotoHandler>();
            services.AddSingleton<IPersistenceHandler<IUpdateMotoCommand>, MotoHandler>();
            services.AddSingleton<IPersistenceHandler<IDeleteMotoCommand>, MotoHandler>();
            services.AddSingleton<IPersistenceHandler<ICreatedUserCommand>, UserHandler>();
            services.AddSingleton<IPersistenceHandler<IUpdateUserCommand>, UserHandler>();
            services.AddSingleton<IPersistenceHandler<ICreateRentalPlanUserCommand>, RentalPlanUserHandler>();
            services.AddSingleton<ISearchHandler<IGetByLicensePlateMotoCommand, MotoValueObject>, MotoHandler>();
            services.AddSingleton<ISearchHandler<IListAllMotoCommand, List<MotoValueObject>>, MotoHandler>();
            services.AddSingleton<ISearchHandler<IListAllRentalPlanCommand, List<RentalPlanValueObject>>, RentalPlanHandler>();

            return services;
        }
    }
}
