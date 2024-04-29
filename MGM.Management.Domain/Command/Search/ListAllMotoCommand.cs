using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Search
{
    public class ListAllMotoCommand(IMotoRepository motoRepository) : IListAllMotoCommand
    {
        private readonly IMotoRepository _motoRepository = motoRepository;

        public async Task<List<MotoValueObject>?> ExecuteAsync()
        {
            var ret = await _motoRepository.ListAllAsync();

            return ret is null ? default :
                ret.Select(c => c.ToValueObject())
                .ToList();
        }
    }
}
