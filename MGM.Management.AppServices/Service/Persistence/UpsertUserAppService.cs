using MGM.Management.AppServices.Converters;
using MGM.Management.AppServices.Extensions;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Domain.Command.Persistence;
using MGM.Management.Domain.Handler.Persistence;
using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using System.Net;

namespace MGM.Management.AppServices.Service.Persistence
{
    public class UpsertUserAppService(
        IDefaultHttpClientErrorResponseHandler defaultHttpClientErrorResponseHandler,
        IPersistenceHandler<ICreatedUserCommand> createdUserHandler,
        IPersistenceHandler<IUpdateUserCommand> updateUserHandler,
        ICreatedUserCommand createdUserCommand,
        IUpdateUserCommand updateUserCommand) : IUpsertUserAppService
    {
        private readonly IDefaultHttpClientErrorResponseHandler _defaultHttpClientErrorResponseHandler = defaultHttpClientErrorResponseHandler;
        private readonly IPersistenceHandler<ICreatedUserCommand> _createdUserHandler = createdUserHandler;
        private readonly IPersistenceHandler<IUpdateUserCommand> _updateUserHandler = updateUserHandler;
        private readonly ICreatedUserCommand _createdUserCommand = createdUserCommand;
        private readonly IUpdateUserCommand _updateUserCommand = updateUserCommand;

        public async Task UpsertAsync(UserViewModel viewModel)
        {
            CreateCnhFile(viewModel);

            if (!string.IsNullOrEmpty(viewModel.Id))
            {
                _updateUserCommand.AddPayload(viewModel.ToValueObject());
                await _updateUserHandler.Handle(_updateUserCommand);
            }
            else
            {
                _createdUserCommand.AddPayload(viewModel.ToValueObject());
                await _createdUserHandler.Handle(_createdUserCommand);
            }
        }

        private void CreateCnhFile(UserViewModel viewModel)
        {
            var buffer = Convert.FromBase64String(viewModel.CnhImageBase64);

            string fileExtension = FileExtensions.TryGetExtension(buffer) ?? throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                string.Empty,
                $"Arquivo não suportado. Por favor, informe um arquivo válido nas extensões bpm ou png.");

            var fileName = $"{viewModel.Name}_{DateTime.Now:dd_MM_yyyy_hh_mm_ss}";

            buffer.ExportToFile(AppDomain.CurrentDomain.BaseDirectory, fileName, fileExtension);

            viewModel.CnhFileName = string.Format("{0}.{1}", fileName, fileExtension);
        }
    }
}
