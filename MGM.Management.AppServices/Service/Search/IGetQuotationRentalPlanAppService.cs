using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.AppServices.Service.Search
{
    public interface IGetQuotationRentalPlanAppService
    {
        Task<RentalPlanQuotationViewModel> GetByExpectedRentalEndDateByRentalPlanIdAsync(DateTime expectedRentalEndDate, string rentalPlanId);
    }
}
