using CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCreditInfoId;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCustomerId;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.ValidateCreditCardNumber;
using CreditCardStatement.Application.Exception;
using CreditCardStatement.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardStatement.Api.Controllers
{
    /// <summary>
    /// Controlador para manajera la informacion de las tarjetas
    /// </summary>
    [Route("api/v1/creditCardInfo")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CreditCardInfoController : ControllerBase
    {
        /// <summary>
        /// Endpoint para crear una tarjeta asociada a un cliente
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(
    [FromBody] CreateCreditCardInfoModel model,
    [FromServices] ICreateCreditCardInfoCommand command,
    [FromServices] IValidator<CreateCreditCardInfoModel> validator
    )
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await command.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        /// <summary>
        /// Endpoint para obtener todas las tarjetas asociadas a un cliente
        /// </summary>
        /// <param name="customerId">Id del cliente</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getCreditCardInfoByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCreditCardInfoByCustomerId(
            int customerId,
            [FromServices] ICreditCardInfoByCustomerId query)
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


        /// <summary>
        /// Endpoint para obtener toda la informacion de una tarjeta
        /// </summary>
        /// <param name="crediCardInfoId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getCreditCardInfoById/{crediCardInfoId}")]
        public async Task<IActionResult> GetCreditCardInfoById(
            int crediCardInfoId,
            [FromServices] IGetCreditCardInfoByCreditInfoId query)
        {
            if (crediCardInfoId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, crediCardInfoId));
            }

            var data = await query.Execute(crediCardInfoId);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        /// <summary>
        /// Endpoint para validar si un numero de tarjeta ya existe
        /// </summary>
        /// <param name="crediCardNumber">Numero de tarjeta</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("validateCreditCardNumber/{crediCardNumber}")]
        public async Task<IActionResult> ValidateCreditCardNumber(
            string crediCardNumber,
            [FromServices] IValidateCreditCardNumber query)
        {
            if (crediCardNumber.Length == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, crediCardNumber));
            }

            var data = await query.Execute(crediCardNumber);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
