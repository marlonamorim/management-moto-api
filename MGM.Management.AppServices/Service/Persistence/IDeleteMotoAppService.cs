using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Persistence
{
    public interface IDeleteMotoAppService
    {
        Task ExecuteAsync(MotoViewModel viewModel);
    }
}
