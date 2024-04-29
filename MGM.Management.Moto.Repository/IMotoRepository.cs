using MGM.Management.Moto.Entities;

namespace MGM.Management.Moto.Repository
{
    public interface IMotoRepository
    {
        Task CreateAsync(MotoEntity entity);

        Task<MotoEntity> GetByLicensePlateAsync(string licensePlate);

        Task<MotoEntity> GetByIdAsync(string id);

        Task<IEnumerable<MotoEntity>> ListAllAsync();

        Task UpdateAsync(MotoEntity entity);

        Task RemoveAsync(string id);
    }
}
