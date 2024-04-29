using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Converters
{
    public static class RentalPlanConverter
    {
        public static RentalPlanViewModel ToViewModel(this RentalPlanValueObject vo) =>
            new()
            {
                Id = vo.Id,
                Name = vo.Name,
                Days = vo.Days,
                CostPerDay = vo.CostPerDay
            };

        public static RentalPlanQuotationViewModel ToViewModel(this RentalPlanQuotationValueObject vo) =>
            new()
            {
                FineRateAppliedInPercentage = vo.FineRateAppliedInPercentage,
                FineRateAppliedInMonetaryValue = vo.FineRateAppliedInMonetaryValue,
                AdditionalTotalCost = vo.AdditionalTotalCost,
                TotalCost = vo.TotalCost
            };
    }
}
