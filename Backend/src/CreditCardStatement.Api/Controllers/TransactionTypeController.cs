using CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType;
using CreditCardStatement.Application.Exception;
using CreditCardStatement.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardStatement.Api.Controllers
{
    /// <summary>
    /// Controlador para obtener la informacion de tipo de transacciones
    /// </summary>
    [Route("api/v1/transactionType")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TransactionTypeController : ControllerBase
    {
        /// <summary>
        /// Endpoint para obtener todos los tipos de transacciones
        /// </summary>
        /// <param name="_query"></param>
        /// <returns></returns>
        [HttpGet("GetAllTransactionsType")]
        public async Task<IActionResult> GetAllTransactionsType(
            [FromServices] IGetAllTransactionsType _query
        )
        {
            var data = await _query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
