using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class UpdateMotoCommand(IMotoRepository motoRepository, IMotoAssertion motoAssertion) : IUpdateMotoCommand
    {
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMotoAssertion _motoAssertion = motoAssertion;

        private MotoValueObject? Moto;

        public void AddPayload(MotoValueObject obj)
            => Moto = obj;

        public async Task ExecuteAsync()
        {
            _motoAssertion.MotoNeedsToBeValid(Moto);

            var moto = await _motoRepository.GetByIdAsync(Moto!.Id!);

            _motoAssertion.MotoEntityMustExists(moto, Moto.Id!);

            var motoWithLicensePlateEquals = await _motoRepository.GetByLicensePlateAsync(Moto.LicensePlate);

            _motoAssertion.ThereMustBeNoMotoWhithLicensePlate(motoWithLicensePlateEquals, Moto.LicensePlate);

            moto.AddBrand(Moto.Brand);
            moto.AddLicensePlate(Moto.LicensePlate);
            moto.AddManufactoreYear(Moto.ManufactureYear);

            await _motoRepository.UpdateAsync(moto);
        }
    }
}
