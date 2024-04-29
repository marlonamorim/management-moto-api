using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Persistence
{
    public interface IUpsertMotoAppService
    {
        Task UpsertAsync(MotoViewModel viewModel);
    }
}
