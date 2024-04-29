using MGM.Management.Domain.Command.Search;
using MGM.Management.Domain.Handler.Search;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Handler
{
    public class RentalPlanHandler :
        ISearchHandler<IListAllRentalPlanCommand, List<RentalPlanValueObject>>
    {
        public async Task<List<RentalPlanValueObject>?> Handle(IListAllRentalPlanCommand command)
            => await command.ExecuteAsync();
    }
}
