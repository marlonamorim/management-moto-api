using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Search
{
    public class GetByLicensePlateMotoCommand(IMotoRepository motoRepository, IMotoAssertion motoAssertion) : IGetByLicensePlateMotoCommand
    {
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMotoAssertion _motoAssertion = motoAssertion;

        private string? LicensePlate;

        public void AddLicensePlate(string licensePlate)
            => LicensePlate = licensePlate;

        public async Task<MotoValueObject?> ExecuteAsync()
        {
            _motoAssertion.LicensePlateNeedsToBeFill(LicensePlate);

            var ret = await _motoRepository.GetByLicensePlateAsync(LicensePlate!);
            return ret is null ? default :
                    ret.ToValueObject();
        }
    }
}
