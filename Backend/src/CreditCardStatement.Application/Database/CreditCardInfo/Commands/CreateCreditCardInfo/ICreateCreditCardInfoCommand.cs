namespace CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo
{
    public interface ICreateCreditCardInfoCommand
    {
        Task<CreateCreditCardInfoModel> Execute(CreateCreditCardInfoModel model);
    }
}
