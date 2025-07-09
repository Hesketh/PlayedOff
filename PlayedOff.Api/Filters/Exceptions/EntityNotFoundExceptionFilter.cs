using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayedOff.Domain.Exceptions;

namespace PlayedOff.Api.Filters.Exceptions;

public class EntityNotFoundExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EntityNotFoundException)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Content = context.Exception.ToString()
            };
        }
    }
}