namespace MGM.Management.Domain.ValueObjects
{
    public class RentalPlanUserValueObject : ValueObject
    {
        public string RentalPlanId { get; set; } = string.Empty;

        public string MotoId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public DateTime RentalStartDate { get; set; }
        
        public DateTime RentalEndDate { get; set; }

        public DateTime ExpectedRentalEndDate { get; set; }

        public decimal RentalTotalCost { get; set; }

        public RentalPlanValueObject RentalPlan { get; set; } = new();

        public MotoValueObject Moto { get; set; } = new();

    }
}
