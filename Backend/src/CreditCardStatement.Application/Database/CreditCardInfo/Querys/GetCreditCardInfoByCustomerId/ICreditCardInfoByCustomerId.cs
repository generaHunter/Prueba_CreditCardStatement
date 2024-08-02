namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCustomerId
{
    public interface ICreditCardInfoByCustomerId
    {
        Task<List<CreditCardInfoByCustomerIdModel>> Execute(int CustomerId);
    }
}
