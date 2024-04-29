using MGM.Management.Moto.Entities;

namespace MGM.Management.Moto.Repository
{
    public interface IRentalPlanUserRepository
    {
        Task CreateAsync(RentalPlanUserEntity entity);
    }
}
