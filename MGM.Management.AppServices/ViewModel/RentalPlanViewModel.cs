namespace MGM.Management.AppServices.ViewModel
{
    public class RentalPlanViewModel
    {
        public string? Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Days { get; set; }

        public decimal CostPerDay { get; set; }
    }
}
