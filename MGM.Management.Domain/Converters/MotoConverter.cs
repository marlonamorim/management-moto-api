using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Converters
{
    public static class MotoConverter
    {
        public static MotoEntity ToEntity(this MotoValueObject vo)
        {
            MotoEntity entity = new();
            entity.AddId(vo.Id);
            entity.AddLicensePlate(vo.LicensePlate);
            entity.AddBrand(vo.Brand);
            entity.AddManufactoreYear(vo.ManufactureYear);

            return entity;
        }

        public static MotoValueObject ToValueObject(this MotoEntity entity) =>
            new()
            {
                Id = entity.Id,
                LicensePlate = entity.LicensePlate,
                ManufactureYear = entity.ManufactureYear,
                Brand = entity.Brand
            };
    }
}
