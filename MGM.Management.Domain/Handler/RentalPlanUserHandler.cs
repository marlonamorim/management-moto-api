using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;

namespace MGM.Management.Domain.Handler
{
    public class RentalPlanUserHandler() :
        IPersistenceHandler<ICreateRentalPlanUserCommand>
    {
        public async Task Handle(ICreateRentalPlanUserCommand command)
            => await command.ExecuteAsync();
    }
}
