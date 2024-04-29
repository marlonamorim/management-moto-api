using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.DataSettings;
using MGM.Management.Moto.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Management.Moto.Infrastructure.Repositories
{
    internal class RentalPlanUserRepository : IRentalPlanUserRepository
    {
        private readonly IMongoCollection<RentalPlanUserEntity> _collection;

        public RentalPlanUserRepository(IOptions<MotoStoreDatabaseSettings> motoStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            motoStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                motoStoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<RentalPlanUserEntity>(
                motoStoreDatabaseSettings.Value.RentalPlanUserCollectionName);
        }

        public async Task CreateAsync(RentalPlanUserEntity entity)
            => await _collection.InsertOneAsync(entity);
    }
}
