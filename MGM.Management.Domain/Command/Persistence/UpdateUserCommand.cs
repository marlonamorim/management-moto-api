using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class UpdateUserCommand(IUserRepository motoRepository) : IUpdateUserCommand
    {
        private readonly IUserRepository _userRepository = motoRepository;

        private UserValueObject? User;

        public void AddPayload(UserValueObject obj)
            => User = obj;

        public async Task ExecuteAsync()
        {
            var user = await _userRepository.GetByIdAsync(User!.Id!);

            user.AddCnhImageName(User.CnhImageName);

            await _userRepository.UpdateAsync(user);
        }
    }
}
