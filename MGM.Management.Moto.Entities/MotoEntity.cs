using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Management.Moto.Entities
{
    public class MotoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        public string LicensePlate { get; private set; } = string.Empty;

        public string Brand { get; private set; } = string.Empty;

        public int ManufactureYear { get; private set; }

        public void AddId(string? value) => Id = value;
        public void AddLicensePlate(string value) => LicensePlate = value;

        public void AddBrand(string value) => Brand = value;

        public void AddManufactoreYear(int value) => ManufactureYear = value;
    }
}
