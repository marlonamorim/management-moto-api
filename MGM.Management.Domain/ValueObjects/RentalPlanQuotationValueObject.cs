namespace MGM.Management.Domain.ValueObjects
{
    public class RentalPlanQuotationValueObject
    {
        public decimal TotalCost { get; set; }

        public decimal AdditionalTotalCost { get; set; }

        public decimal FineRateAppliedInMonetaryValue { get; set; }

        public decimal FineRateAppliedInPercentage { get; set; }
    }
}
