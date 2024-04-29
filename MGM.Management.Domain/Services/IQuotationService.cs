using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Services
{
    public interface IQuotationService
    {
        Task<RentalPlanQuotationValueObject> GetByExpectedRentalEndDateAsync(
            DateTime expectedRentalEndDate, string rentalPlanId);
    }
}
