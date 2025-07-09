using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayedOff.Domain.Exceptions;

namespace PlayedOff.Api.Filters.Exceptions;

public class UserForbiddenExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is UserForbiddenException)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.Forbidden,
                Content = context.Exception.ToString()
            };
        }
    }
}