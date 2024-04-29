using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Search
{
    public interface IGetMotoAppService
    {
        Task<MotoViewModel?> GetByLicensePlateAsync(string licensePlate);

        Task<IEnumerable<MotoViewModel?>?> ListAllAsync();
    }
}
