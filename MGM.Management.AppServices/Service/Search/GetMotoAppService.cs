using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Search;
using MGM.Management.Domain.Handler.Search;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Service.Search
{
    public class GetMotoAppService(
        ISearchHandler<IGetByLicensePlateMotoCommand, MotoValueObject> handlerGetByLicensePlate,
        ISearchHandler<IListAllMotoCommand, List<MotoValueObject>> handlerListAll,
        IGetByLicensePlateMotoCommand getByLicensePlateCommand,
        IListAllMotoCommand listAllCommand) : IGetMotoAppService
    {
        private readonly ISearchHandler<IGetByLicensePlateMotoCommand, MotoValueObject> _handlerGetByLicensePlate = handlerGetByLicensePlate;
        private readonly ISearchHandler<IListAllMotoCommand, List<MotoValueObject>> _handlerListAll = handlerListAll;
        private readonly IGetByLicensePlateMotoCommand _getByLicensePlateCommand = getByLicensePlateCommand;
        private readonly IListAllMotoCommand _listAllCommand = listAllCommand;

        public async Task<MotoViewModel?> GetByLicensePlateAsync(string licensePlate)
        {
            _getByLicensePlateCommand.AddLicensePlate(licensePlate);
            var ret = await _handlerGetByLicensePlate.Handle(_getByLicensePlateCommand);

            return ret is null ? default :
                ret.ToViewModel();
        }

        public async Task<IEnumerable<MotoViewModel?>?> ListAllAsync()
        {
            var ret = await _handlerListAll.Handle(_listAllCommand);

            return ret is null ? default :
                ret.Select(c => c.ToViewModel());
        }
    }
}
