namespace MGM.Management.Moto.Infrastructure.DataSettings
{
    public class MotoStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MotocycleCollectionName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;

        public string RentalPlanCollectionName { get; set; } = null!;

        public string RentalPlanUserCollectionName { get; set; } = null!;
    }
}
