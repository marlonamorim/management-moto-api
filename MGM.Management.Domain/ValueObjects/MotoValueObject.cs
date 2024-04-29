namespace MGM.Management.Domain.ValueObjects
{
    public class MotoValueObject : ValueObject
    {
        public string LicensePlate { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public int ManufactureYear { get; set; }
    }
}