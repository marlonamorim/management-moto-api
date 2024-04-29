using System.Net;

namespace MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientResourceNotFoundException(string message) : HttpClientRequestException(message, HttpStatusCode.NotFound)
    {
    }
}
