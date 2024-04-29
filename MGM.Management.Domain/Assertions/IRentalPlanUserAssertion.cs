using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Assertions
{
    public interface IRentalPlanUserAssertion
    {
        void ThereMustBeUserId(string? userId);

        void UserThereMustBeCnhCategory(UserEntity user, ICollection<string> cnhCategories);

        void ThereMustBeRentalPlan(RentalPlanEntity? rentalPlan, string rentalPlanId);
    }
}
