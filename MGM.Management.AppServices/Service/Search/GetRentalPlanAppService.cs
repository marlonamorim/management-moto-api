using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Search;
using MGM.Management.Domain.Handler.Search;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Service.Search
{
    public class GetRentalPlanAppService(ISearchHandler<IListAllRentalPlanCommand, List<RentalPlanValueObject>> handler,
        IListAllRentalPlanCommand command) : IGetRentalPlanAppService
    {
        private readonly ISearchHandler<IListAllRentalPlanCommand, List<RentalPlanValueObject>> _handler = handler;
        private readonly IListAllRentalPlanCommand _command = command;

        public async Task<IEnumerable<RentalPlanViewModel?>?> ListAllAsync()
        {
            var ret = await _handler.Handle(_command);

            return ret is null ? default :
                ret.Select(c => c.ToViewModel());
        }
    }
}
