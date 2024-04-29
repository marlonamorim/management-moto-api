using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.Converters;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class CreatedMotoCommand(IMotoRepository motoRepository, IMotoAssertion motoAssertion) : ICreatedMotoCommand
    {
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMotoAssertion _motoAssertion = motoAssertion;

        private MotoValueObject? Moto;

        public void AddPayload(MotoValueObject obj)
            => Moto = obj;

        public async Task ExecuteAsync()
        {
            _motoAssertion.MotoNeedsToBeValid(Moto);

            var moto = await _motoRepository.GetByLicensePlateAsync(Moto!.LicensePlate);

            _motoAssertion.ThereMustBeNoMotoWhithLicensePlate(moto, Moto!.LicensePlate);

            await _motoRepository.CreateAsync(Moto!.ToEntity());
        }
    }
}
