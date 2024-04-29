using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;

namespace MGM.Management.AppServices.Service.Persistence
{
    public class CreateRentalPlanUserAppService(IPersistenceHandler<ICreateRentalPlanUserCommand> handler,
        ICreateRentalPlanUserCommand command) : ICreateRentalPlanUserAppService
    {
        private readonly IPersistenceHandler<ICreateRentalPlanUserCommand> _handler = handler;
        private readonly ICreateRentalPlanUserCommand _command = command;

        public async Task CreateAsync(RentalPlanUserViewModel viewModel)
        {
            _command.AddPayload(viewModel.ToValueObject());
            await _handler.Handle(_command);
        }
    }
}
