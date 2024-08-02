using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using CreditCardStatement.Domain.Entities.CreditCardTransaction;

namespace CreditCardStatement.Application.Database.CreditCardTransaction.Commands.CreateCreditCardTransaction
{
    public interface ICreateCreditCardTransaction
    {
        Task<TransactionResultEntity> Execute(CommonCreditCardTransactionModel model);
    }
}
