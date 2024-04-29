using MGM.Management.Moto.Entities;

namespace MGM.Management.Moto.Repository
{
    public interface IUserRepository
    {
        Task<bool> CredentialIsValidAsync(string email, string password);

        Task<bool> ExistsByCnhNumberAsync(string cnh);

        Task<bool> ExistsByCnpjAsync(string document);

        Task<bool> ExistsByEmailAsync(string email);

        Task<UserEntity> GetByEmailAsync(string email);

        Task CreateAsync(UserEntity user);

        Task<UserEntity> GetByIdAsync(string id);

        Task UpdateAsync(UserEntity entity);
    }
}
