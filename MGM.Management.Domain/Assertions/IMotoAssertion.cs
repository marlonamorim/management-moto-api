using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Assertions
{
    public interface IMotoAssertion
    {
        void MotoNeedsToBeValid(MotoValueObject? valueObject);

        void ThereMustBeNoMotoWhithLicensePlate(MotoEntity? moto, string licensePlate);

        void LicensePlateNeedsToBeFill(string? licensePlate);

        void MotoEntityMustExists(MotoEntity? moto, string motoId);
    }
}
