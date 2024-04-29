using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Command.Search
{
    public interface IListAllRentalPlanCommand : ISearchCommand<List<RentalPlanValueObject>>
    {
    }
}
