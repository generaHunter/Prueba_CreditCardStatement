using CreditCardStatement.Application.Database.Customer.Commands.CreateCustomer;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using CreditCardStatement.Application.Database.Customer.Querys.GetAllCustomers;
using CreditCardStatement.Application.Database.Customer.Querys.GetCustomerById;
using CreditCardStatement.Application.Exception;
using CreditCardStatement.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardStatement.Api.Controllers
{
    /// <summary>
    /// Controlador para manejar la información de los clientes.
    /// </summary>
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Endpoint para crear un cliente nuevo
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CommonCustomerModel model,
            [FromServices] ICreateCustomerCommand command,
            [FromServices] IValidator<CommonCustomerModel> validator
            )
        {
            var validate = await validator.ValidateAsync( model );

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await command.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        /// <summary>
        /// Endpoint para obtener todos los clientes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers(
            [FromServices] IGetAllCustomerQuery query
            )
        {
            var data = await query.Execute();
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        /// <summary>
        /// Endpoint para obtener un cliente por su codigo
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet("getCustomerById/{customerId}")]
        public async Task<IActionResult> GetUserById(
            int customerId,
            [FromServices] IGetCustomerByIdQuery query)
        {
            if (customerId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, customerId));
            }

            var data = await query.Execute(customerId);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

    }
}
