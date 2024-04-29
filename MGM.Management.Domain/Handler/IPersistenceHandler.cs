using MGM.Management.Domain.Command;

namespace MGM.Management.Domain.Handler.Persistence
{
    public interface IPersistenceHandler<TIn> 
        where TIn : ICommand
    {
        Task Handle(TIn command);
    }
}
