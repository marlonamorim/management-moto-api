using MGM.Management.Moto.Entities;

namespace MGM.Management.Moto.Repository
{
    public interface IRentalPlanRepository
    {
        Task<IEnumerable<RentalPlanEntity>> ListAllAsync();

        Task<RentalPlanEntity> GetByIdAsync(string id);
    }
}
