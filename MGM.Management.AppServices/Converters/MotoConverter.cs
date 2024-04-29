using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Converters
{
    public static class MotoConverter
    {
        public static MotoValueObject ToValueObject(this MotoViewModel motoViewModel) =>
            new () { 
                Id = motoViewModel.Id,
                LicensePlate = motoViewModel.LicensePlate,
                ManufactureYear = motoViewModel.ManufactureYear,
                Brand = Enum.GetName(motoViewModel.Brand)
            };

        public static MotoViewModel ToViewModel(this MotoValueObject motoValueObject) =>
            new()
            {
                Id = motoValueObject.Id,
                LicensePlate = motoValueObject.LicensePlate,
                ManufactureYear = motoValueObject.ManufactureYear,
                Brand = (Brand)Enum.Parse(typeof(Brand), motoValueObject.Brand)
            };
    }
}
