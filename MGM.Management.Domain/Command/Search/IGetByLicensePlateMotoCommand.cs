using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.Domain.Command.Search
{
    public interface IGetByLicensePlateMotoCommand : ISearchCommand<MotoValueObject>
    {
        void AddLicensePlate(string licensePlate);
    }
}
