using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;

namespace MGM.Management.AppServices.Service.Persistence
{
    public class UpsertMotoAppService(
        IPersistenceHandler<ICreatedMotoCommand> createdMotoHandler,
        IPersistenceHandler<IUpdateMotoCommand> updateMotoHandler,
        ICreatedMotoCommand createdMotoCommand,
        IUpdateMotoCommand updateMotoCommand) : IUpsertMotoAppService
    {
        private readonly IPersistenceHandler<ICreatedMotoCommand> _createdMotoHandler = createdMotoHandler;
        private readonly ICreatedMotoCommand _createdMotoCommand = createdMotoCommand;
        private readonly IPersistenceHandler<IUpdateMotoCommand> _updateMotoHandler = updateMotoHandler;
        private readonly IUpdateMotoCommand _updateMotoCommand = updateMotoCommand;

        public async Task UpsertAsync(MotoViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Id))
            {
                _updateMotoCommand.AddPayload(viewModel.ToValueObject());
                await _updateMotoHandler.Handle(_updateMotoCommand);
            }
            else
            {
                _createdMotoCommand.AddPayload(viewModel.ToValueObject());
                await _createdMotoHandler.Handle(_createdMotoCommand);
            }
        }
    }
}
