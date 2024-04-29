using MGM.Management.Moto.Infrastructure.Api.ErrorHandling;
using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MGM.Management.Moto.Infrastructure.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IActionResultErrorBuilder _actionResultErrorBuilder;
        public ExceptionFilter(IActionResultErrorBuilder actionResultErrorBuilder)
        {
            _actionResultErrorBuilder = actionResultErrorBuilder;
        }

        public void OnException(ExceptionContext context)
        {

            context.Result = context.Exception switch
            {
                HttpClientUnauthorizedException httpClientUnauthorizedException => _actionResultErrorBuilder.HttpClientUnauthorizedAccess(httpClientUnauthorizedException),
                UnauthorizedAccessException unauthorizedAccessException => _actionResultErrorBuilder.HttpClientUnauthorizedAccess(unauthorizedAccessException),
                HttpClientBadRequestException badRequestException => _actionResultErrorBuilder.HttpClientBadRequestException(badRequestException),
                HttpClientResourceNotFoundException resourceNotFoundException => _actionResultErrorBuilder.HttpClientResourceNotFoundException(resourceNotFoundException),
                _ => _actionResultErrorBuilder.UnknowException(context.Exception)
            };
        }
    }
}
