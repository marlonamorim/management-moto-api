using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Converters
{
    public static class RentalPlanUserConverter
    {
        public static RentalPlanUserValueObject ToValueObject(this RentalPlanUserViewModel viewModel) =>
            new()
            {
                RentalPlanId = viewModel.RentalPlanId,
                MotoId = viewModel.MotoId,
                ExpectedRentalEndDate = viewModel.ExpectedRentalEndDate,
            };
    }
}
