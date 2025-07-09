using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayedOff.Domain.Exceptions;

namespace PlayedOff.Api.Filters.Exceptions;

public class EntityCreateFailedExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EntityCreateFailedException)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Content = context.Exception.ToString()
            };
        }
    }
}