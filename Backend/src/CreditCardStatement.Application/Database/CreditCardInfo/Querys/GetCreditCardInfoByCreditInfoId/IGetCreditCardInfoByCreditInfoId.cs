using CreditCardStatement.Application.Database.CreditCardInfo.Querys.CommonModel;

namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCreditInfoId
{
    public interface IGetCreditCardInfoByCreditInfoId
    {
        Task<CommonModelCreditCardInfo> Execute(int CreditCardInfoId);
    }
}
