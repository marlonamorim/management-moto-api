using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.DataSettings;
using MGM.Management.Moto.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Management.Moto.Infrastructure.Repositories
{
    internal class MotoRepository : IMotoRepository
    {
        private readonly IMongoCollection<MotoEntity> _motoCollection;

        public MotoRepository(IOptions<MotoStoreDatabaseSettings> motoStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            motoStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                motoStoreDatabaseSettings.Value.DatabaseName);

            _motoCollection = mongoDatabase.GetCollection<MotoEntity>(
                motoStoreDatabaseSettings.Value.MotocycleCollectionName);
        }

        public async Task CreateAsync(MotoEntity entity)
            => await _motoCollection.InsertOneAsync(entity);

        public async Task RemoveAsync(string id)
            => await _motoCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<MotoEntity> GetByLicensePlateAsync(string licensePlate)
            => await _motoCollection.Find(x => x.LicensePlate == licensePlate).FirstOrDefaultAsync();

        public async Task<MotoEntity> GetByIdAsync(string id)
            => await _motoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<MotoEntity>> ListAllAsync()
            => await _motoCollection.Find(_ => true).ToListAsync();

        public async Task UpdateAsync(MotoEntity entity)
            => await _motoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}
