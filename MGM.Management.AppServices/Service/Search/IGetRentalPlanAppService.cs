using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Search
{
    public interface IGetRentalPlanAppService
    {
        Task<IEnumerable<RentalPlanViewModel?>?> ListAllAsync();
    }
}
