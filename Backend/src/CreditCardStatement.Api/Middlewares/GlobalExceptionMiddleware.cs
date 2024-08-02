using CreditCardStatement.Domain.Models;
using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace CreditCardStatement.Api.Middlewares
{
    /// <summary>
    /// Clase para implementar el manejo global de excepciones
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="next"></param>
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Este método se invoca en cada solicitud. Intenta ejecutar el siguiente middleware y captura cualquier excepción no manejada.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Este método maneja la excepción, configurando el tipo de contenido de la respuesta a JSON y estableciendo el código de estado HTTP a 500 Internal Server Error. Luego, serializa el mensaje de la excepción en un formato JSON y lo devuelve al cliente.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is BadRequestException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var response = new BaseResponseModel
            {
                StatusCode = context.Response.StatusCode,
                Success = false,
                Message = exception.Message,
                Data = null
            };

            var jsonResponse = JsonConvert.SerializeObject(response);

            return context.Response.WriteAsync(jsonResponse);
        }


    }
}
