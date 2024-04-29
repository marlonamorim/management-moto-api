using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Converters
{
    public static class UserConverter
    {
        public static UserEntity ToEntity(this UserValueObject vo)
        {
            UserEntity entity = new();
            entity.AddLogin(vo.Login);
            entity.AddBirthDate(vo.BirthDate);
            entity.AddCnh(vo.Cnh);
            entity.AddCnpj(vo.Cnpj);
            entity.AddCnhCategory(vo.CnhCategory);
            entity.AddCnhImageName(vo.CnhImageName);
            entity.AddName(vo.Name);
            entity.AddRoles(vo.Roles);
            entity.AddPassword(vo.Password);

            return entity;
        }
    }
}
