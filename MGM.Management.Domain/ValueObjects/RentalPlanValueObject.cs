namespace MGM.Management.Domain.ValueObjects
{
    public class RentalPlanValueObject : ValueObject
    {
        public string Name { get; set; } = string.Empty;

        public int Days { get; set; }

        public decimal CostPerDay { get; set; }

        public bool UnderDeliveryPerformance { get; set; }

        public decimal FineRateAppliedInPercentage { get; set; }

        public decimal FineRateAppliedInMonetaryValue { get; set; }
    }
}
