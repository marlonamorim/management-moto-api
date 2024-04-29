using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.DataSettings;
using MGM.Management.Moto.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Management.Moto.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _userCollection;

        public UserRepository(IOptions<MotoStoreDatabaseSettings> motoStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            motoStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                motoStoreDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<UserEntity>(
                motoStoreDatabaseSettings.Value.UserCollectionName);
        }

        public async Task CreateAsync(UserEntity user)
            => await _userCollection.InsertOneAsync(user);

        public async Task<bool> CredentialIsValidAsync(string email, string password)
            => await _userCollection.Find(x => x.Login == email && x.Password == password).AnyAsync();

        public async Task<bool> ExistsByCnhNumberAsync(string cnh)
            => await _userCollection.Find(x => x.Cnh == cnh).AnyAsync();

        public async Task<bool> ExistsByCnpjAsync(string document)
            => await _userCollection.Find(x => x.Cnpj == document).AnyAsync();

        public async Task<bool> ExistsByEmailAsync(string email)
            => await _userCollection.Find(x => x.Login == email).AnyAsync();

        public async Task<UserEntity> GetByEmailAsync(string email)
            => await _userCollection.Find(x => x.Login == email).FirstOrDefaultAsync();

        public async Task<UserEntity> GetByIdAsync(string id)
            => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(UserEntity entity)
            => await _userCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}
