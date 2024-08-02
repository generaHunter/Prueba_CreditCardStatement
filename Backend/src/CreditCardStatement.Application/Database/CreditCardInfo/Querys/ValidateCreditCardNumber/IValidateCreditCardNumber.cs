namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.ValidateCreditCardNumber
{
    public interface IValidateCreditCardNumber
    {
        Task<ValidateCreditCardNumberModel> Execute(string cardNumber);
    }
}
