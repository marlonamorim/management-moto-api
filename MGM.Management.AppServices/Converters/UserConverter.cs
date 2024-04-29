using MGM.Management.AppServices.Extensions;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.ValueObjects;

namespace MGM.Management.AppServices.Converters
{
    public static class UserConverter
    {
        public static UserValueObject ToValueObject(this UserViewModel viewModel) =>
            new()
            {
                Id = viewModel.Id,
                BirthDate = viewModel.BirthDate,
                Cnh = viewModel.Cnh,
                CnhImageName = viewModel.CnhFileName,
                Cnpj = viewModel.Cnpj,
                Login = viewModel.Login,
                Name = viewModel.Name,
                Password = viewModel.Password,
                CnhCategory = Enum.GetName(viewModel.CnhCategory),
                Roles = [viewModel.UserType.GetDescription()]
            };
    }
}
