using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Command
{
    public interface ISearchCommand<TOut> : ICommand 
        where TOut : new()
    {
        Task<TOut?> ExecuteAsync();
    }

    public interface IPersistenceCommand<TIn> : ICommand 
        where TIn : new()
    {
        void AddPayload(TIn obj);

        Task ExecuteAsync();
    }

    public interface ICommand
    {
    }
}
