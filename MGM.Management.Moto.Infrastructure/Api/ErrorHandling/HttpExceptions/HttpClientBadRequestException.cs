using System.Net;

namespace MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientBadRequestException(string message) : HttpClientRequestException(message, HttpStatusCode.BadRequest)
    {
    }
}
