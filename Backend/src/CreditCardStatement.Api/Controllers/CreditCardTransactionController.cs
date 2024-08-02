using CreditCardStatement.Application.Database.CreditCardTransaction.Commands.CreateCreditCardTransaction;
using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber;
using CreditCardStatement.Application.Exception;
using CreditCardStatement.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardStatement.Api.Controllers
{
    /// <summary>
    /// Controlador para manajar la informacion las transacciones de una tarjeta
    /// </summary>
    [Route("api/v1/creditCardTransaction")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CreditCardTransactionController : ControllerBase
    {

        /// <summary>
        /// Endpoint para crear una transaccion a una tarjeta
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CommonCreditCardTransactionModel model,
            [FromServices] ICreateCreditCardTransaction command,
            [FromServices] IValidator<CommonCreditCardTransactionModel> validator
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
        /// Endpoint para obtener todas las transacciones de una tarjeta
        /// </summary>
        /// <param name="cardInfoId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getCreditCardTransactionsByCardInfoId/{cardInfoId}")]
        public async Task<IActionResult> getCreditCardTransactionsByCardInfoId(
            int cardInfoId,
            [FromServices] IGetCreditCardTransactionsByCardInfoId query)
        {
            if (cardInfoId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, cardInfoId));
            }

            var data = await query.Execute(cardInfoId);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
