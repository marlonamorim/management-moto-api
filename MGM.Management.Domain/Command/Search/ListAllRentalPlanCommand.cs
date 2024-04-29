using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Search
{
    public class ListAllRentalPlanCommand(IRentalPlanRepository repository) : IListAllRentalPlanCommand
    {
        private readonly IRentalPlanRepository _repository = repository;

        public async Task<List<RentalPlanValueObject>?> ExecuteAsync()
        {
            var ret = await _repository.ListAllAsync();

            return ret is null ? default :
                ret.Select(c => c.ToValueObject())
                .ToList();
        }
    }
}
