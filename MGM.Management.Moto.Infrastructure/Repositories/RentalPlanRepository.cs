using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.DataSettings;
using MGM.Management.Moto.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Management.Moto.Infrastructure.Repositories
{
    public class RentalPlanRepository : IRentalPlanRepository
    {
        private readonly IMongoCollection<RentalPlanEntity> _rentalPlanCollection;

        public RentalPlanRepository(IOptions<MotoStoreDatabaseSettings> motoStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            motoStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                motoStoreDatabaseSettings.Value.DatabaseName);

            _rentalPlanCollection = mongoDatabase.GetCollection<RentalPlanEntity>(
                motoStoreDatabaseSettings.Value.RentalPlanCollectionName);
        }

        public async Task<IEnumerable<RentalPlanEntity>> ListAllAsync()
            => await _rentalPlanCollection.Find(_ => true).ToListAsync();

        public async Task<RentalPlanEntity> GetByIdAsync(string id)
            => await _rentalPlanCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}
