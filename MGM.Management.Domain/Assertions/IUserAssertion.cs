using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Assertions
{
    public interface IUserAssertion
    {
        void ThereMustBeNoUserWhithCnh(bool exists, string cnh);

        void ThereMustBeNoUserWhithCnpj(bool exists, string document);

        void ThereMustBeNoUserWhithEmail(bool exists, string email);
    }
}
