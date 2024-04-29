using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Command.Search;
using MGM.Management.Domain.Handler.Persistence;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Domain.Handler.Search;

namespace MGM.Management.Domain.Handler
{
    public class MotoHandler() : 
        IPersistenceHandler<ICreatedMotoCommand>,
        IPersistenceHandler<IUpdateMotoCommand>,
        IPersistenceHandler<IDeleteMotoCommand>,
        ISearchHandler<IGetByLicensePlateMotoCommand, MotoValueObject>,
        ISearchHandler<IListAllMotoCommand, List<MotoValueObject>>
    {
        public async Task Handle(ICreatedMotoCommand command)
            => await command.ExecuteAsync();

        public async Task Handle(IUpdateMotoCommand command)
            => await command.ExecuteAsync();

        public async Task<List<MotoValueObject>?> Handle(IListAllMotoCommand command)
            => await command.ExecuteAsync();

        public async Task<MotoValueObject?> Handle(IGetByLicensePlateMotoCommand command)
            => await command.ExecuteAsync();

        public async Task Handle(IDeleteMotoCommand command)
            => await command.ExecuteAsync();
    }
}
