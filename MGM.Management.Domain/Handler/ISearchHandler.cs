using MGM.Management.Domain.Command;

namespace MGM.Management.Domain.Handler.Search
{
    public interface ISearchHandler<TIn, TOut>
        where TIn : ICommand
        where TOut : new()
    {
        Task<TOut?> Handle(TIn command);
    }
}
