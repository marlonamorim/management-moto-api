using MGM.Management.AppServices.ViewModel;

namespace MGM.Management.Moto.Api.Auth
{
    public interface IAccessManager
    {
        Task<bool> CredentialsIsValid(CredentialViewModel credential);

        Task<LoginViewModel> GenerateTokenAsync(string email);
    }
}
