using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;

namespace MGM.Management.AppServices.Service.Persistence
{
    public class DeleteMotoAppService(
        IPersistenceHandler<IDeleteMotoCommand> handler,
        IDeleteMotoCommand command) : IDeleteMotoAppService
    {
        private readonly IPersistenceHandler<IDeleteMotoCommand> _handler = handler;
        private readonly IDeleteMotoCommand _command = command;

        public async Task ExecuteAsync(MotoViewModel viewModel)
        {
            _command.AddPayload(viewModel.ToValueObject());
            await _handler.Handle(_command);
        }
    }
}
