using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Persistence
{
    public interface ICreateRentalPlanUserAppService
    {
        Task CreateAsync(RentalPlanUserViewModel viewModel);
    }
}
