using AutoMapper;
using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using Microsoft.Data.SqlClient;

namespace CreditCardStatement.Application.Database.CreditCardTransaction.Commands.CreateCreditCardTransaction
{
    public class CreateCreditCardTransaction: ICreateCreditCardTransaction
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateCreditCardTransaction(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<TransactionResultEntity> Execute(CommonCreditCardTransactionModel model)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@transactionType", model.TransactionTypeId),
                new SqlParameter("@amount", model.Amount),
                new SqlParameter("@creditCardNumber", model.CreditCardNumber ?? (object)DBNull.Value),
                new SqlParameter("@transactionDate", model.TransactionDate),
                new SqlParameter("@creditCardInfoId", model.CreditCardInfoId),
                new SqlParameter("@description", model.Description ?? (object)DBNull.Value)
             };

            var results = await _databaseService.ExecuteStoredProcedureAsync<TransactionResultEntity>("SP_ADD_TRANSACTION", parameters);

            TransactionResultEntity? result = new()
            {
                CreditCardTransactionId = 0,
                MESSAGE = "No se llevo acabo la transaccion",
                SUCCESS = 0
            };

            if (results != null)
            {
                if (results.Count > 0)
                {
                    result = results.FirstOrDefault();
                }
            }

            return result;
        }
    }
}
