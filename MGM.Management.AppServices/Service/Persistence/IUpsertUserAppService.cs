using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Persistence
{
    public interface IUpsertUserAppService
    {
        Task UpsertAsync(UserViewModel viewModel);
    }
}
