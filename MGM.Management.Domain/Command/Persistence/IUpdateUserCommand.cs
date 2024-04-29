using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Command.Persistence
{
    public interface IUpdateUserCommand : IPersistenceCommand<UserValueObject>
    {
    }
}
