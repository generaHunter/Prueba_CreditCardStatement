

namespace CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo
{
    public class CreateCreditCardInfoModel
    {
        public int CreditCardInfoId { get; set; } = 0;
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal ConfigurableInterestRate { get; set; }
        public decimal ConfigurableMinimumBalancePercentage { get; set; }
    }
}
