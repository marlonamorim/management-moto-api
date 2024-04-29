using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Services;

namespace MGM.Management.AppServices.Service.Search
{
    public class GetQuotationRentalPlanAppService(IQuotationService quotationService) : IGetQuotationRentalPlanAppService
    {
        private readonly IQuotationService _quotationService = quotationService;
        public async Task<RentalPlanQuotationViewModel> GetByExpectedRentalEndDateByRentalPlanIdAsync(DateTime expectedRentalEndDate, string rentalPlanId)
        {
            var ret = await _quotationService.GetByExpectedRentalEndDateAsync(expectedRentalEndDate, rentalPlanId);
            return ret.ToViewModel();
        }
    }
}
