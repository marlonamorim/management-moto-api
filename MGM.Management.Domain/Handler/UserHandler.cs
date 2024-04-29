using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;

namespace MGM.Management.Domain.Handler
{
    public class UserHandler() : 
        IPersistenceHandler<ICreatedUserCommand>,
        IPersistenceHandler<IUpdateUserCommand>
    {
        public async Task Handle(ICreatedUserCommand command)
            => await command.ExecuteAsync();

        public async Task Handle(IUpdateUserCommand command)
            => await command.ExecuteAsync();
    }
}
