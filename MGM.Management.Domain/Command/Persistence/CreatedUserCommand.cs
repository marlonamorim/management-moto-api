using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class CreatedUserCommand(IUserRepository repository, IUserAssertion assertion) : ICreatedUserCommand
    {
        private readonly IUserRepository _repository = repository;
        private readonly IUserAssertion _assertion = assertion;

        private UserValueObject? User;

        public void AddPayload(UserValueObject obj)
            => User = obj;

        public async Task ExecuteAsync()
        {
            var existsUserWithCnh = await _repository.ExistsByCnhNumberAsync(User!.Cnh);

            _assertion.ThereMustBeNoUserWhithCnh(existsUserWithCnh, User.Cnh);

            var existsUserWithCnpj = await _repository.ExistsByCnpjAsync(User.Cnpj);

            _assertion.ThereMustBeNoUserWhithCnpj(existsUserWithCnpj, User.Cnpj);

            var existsUserWithEmail = await _repository.ExistsByEmailAsync(User.Login);

            _assertion.ThereMustBeNoUserWhithEmail(existsUserWithEmail, User.Login);

            await _repository.CreateAsync(User.ToEntity());
        }
    }
}
