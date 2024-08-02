namespace CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber
{
    public interface IGetCreditCardTransactionsByCardInfoId
    {
        Task<List<GetCreditCardTransactionsByCardInfoIdModel>> Execute(int cardInfoId);
    }
}
