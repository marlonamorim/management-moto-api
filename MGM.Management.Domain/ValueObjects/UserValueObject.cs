namespace MGM.Management.Domain.ValueObjects
{
    public class UserValueObject : ValueObject
    {
        public string Name { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Cnh { get; set; } = string.Empty;

        public string CnhCategory { get; set; } = string.Empty;

        public string CnhImageName { get; set; } = string.Empty;

        public string Cnpj { get; set; } = string.Empty;

        public string[] Roles { get; set; } = [];
    }
}
