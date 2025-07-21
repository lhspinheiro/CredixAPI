using CredixAPI.Communication.Response;
using CredixAPI.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CredixAPI.Api.FIlters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CredixException credixException)
        {
            context.HttpContext.Response.StatusCode = (int)credixException.ErrorStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessages
            {
                ErrorMessages = credixException.ErrorMessages()
            });
        }
    }
}