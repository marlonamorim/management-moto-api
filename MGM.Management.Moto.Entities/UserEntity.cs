using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Management.Moto.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Login { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public DateTime BirthDate { get; private set; }

        public string Cnh { get; private set; } = string.Empty;

        public string CnhCategory { get; private set; } = string.Empty;

        public string CnhImageName { get; private set; } = string.Empty;

        public string Cnpj { get; private set; } = string.Empty;

        public string[] Roles { get; private set; } = [];

        public void AddName(string value) => Name = value;

        public void AddLogin(string value) => Login = value;

        public void AddPassword(string value) => Password = value;

        public void AddBirthDate(DateTime value) => BirthDate = value;

        public void AddCnh(string value) => Cnh = value;

        public void AddCnhCategory(string value) => CnhCategory = value;

        public void AddCnhImageName(string value) => CnhImageName = value;

        public void AddCnpj(string value) => Cnpj = value;

        public void AddRoles(string[] value) => Roles = value;
    }
}
