using System.Net;

namespace MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientUnauthorizedException(string message) : HttpClientRequestException(message, HttpStatusCode.Unauthorized)
    {
    }
}
