using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using System.Net;

namespace MGM.Management.Domain.Assertions
{
    public class UserAssertion(IDefaultHttpClientErrorResponseHandler defaultHttpClientErrorResponseHandler) : IUserAssertion
    {
        private readonly IDefaultHttpClientErrorResponseHandler _defaultHttpClientErrorResponseHandler = defaultHttpClientErrorResponseHandler;

        public void ThereMustBeNoUserWhithCnh(bool exists, string cnh)
        {
            if(exists)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Já existe cadastro de usuário com o número de Cnh {cnh}, informado.");
        }

        public void ThereMustBeNoUserWhithCnpj(bool exists, string document)
        {
            if (exists)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Já existe cadastro de usuário com o número de Cnpj {document}, informado.");
        }

        public void ThereMustBeNoUserWhithEmail(bool exists, string email)
        {
            if (exists)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Já existe cadastro de usuário com o email {email}, informado.");
        }
    }
}
