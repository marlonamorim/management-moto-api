using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Services
{
    public class QuotationService(IRentalPlanRepository rentalPlanRepository) : IQuotationService
    {
        private readonly IRentalPlanRepository _rentalPlanRepository = rentalPlanRepository;

        private const int PRECISION_FOR_MONETARY_VALUE = 2;

        public async Task<RentalPlanQuotationValueObject> GetByExpectedRentalEndDateAsync(
            DateTime expectedRentalEndDate, string rentalPlanId)
        {
            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(rentalPlanId);

            var initialDateForLocation = DateTime.Now.AddDays(1);

            var informedTotalDaysForLocation = (expectedRentalEndDate.Date - initialDateForLocation.Date).Days;

            var totalDaysForLocationByPlan = (initialDateForLocation.AddDays(rentalPlan.Days) - initialDateForLocation.Date).Days;

            bool informedDateIsUpperPlanDate = informedTotalDaysForLocation > totalDaysForLocationByPlan;

            int daysDiffBetweenInformedDateAndPlanDate = informedDateIsUpperPlanDate ?
                informedTotalDaysForLocation - totalDaysForLocationByPlan :
                totalDaysForLocationByPlan - informedTotalDaysForLocation;

            decimal additionalTotalCost = 0;
            if (daysDiffBetweenInformedDateAndPlanDate > 0)
            {
                if (!informedDateIsUpperPlanDate && rentalPlan.UnderDeliveryPerformance)
                {
                    var unpaidDailyCost = rentalPlan.CostPerDay * daysDiffBetweenInformedDateAndPlanDate;
                    additionalTotalCost = (unpaidDailyCost * rentalPlan.FineRateAppliedInPercentage) / 100;
                }
                else
                    additionalTotalCost = rentalPlan.FineRateAppliedInMonetaryValue * daysDiffBetweenInformedDateAndPlanDate;
            }

            return new RentalPlanQuotationValueObject
            {
                AdditionalTotalCost = additionalTotalCost,
                FineRateAppliedInMonetaryValue = rentalPlan.FineRateAppliedInMonetaryValue,
                FineRateAppliedInPercentage= rentalPlan.FineRateAppliedInPercentage,
                TotalCost = CalculateTotalCost(rentalPlan, additionalTotalCost)
            };
        }

        static decimal CalculateTotalCost(RentalPlanEntity rentalPlan, decimal additionalTotalCost)
                => Math.Round((rentalPlan.CostPerDay * rentalPlan.Days) + additionalTotalCost, PRECISION_FOR_MONETARY_VALUE);
    }
}
