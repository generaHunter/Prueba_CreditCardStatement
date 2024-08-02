﻿using CreditCardStatement.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CreditCardStatement.Application.Exception
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, context.Exception.Message));
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
