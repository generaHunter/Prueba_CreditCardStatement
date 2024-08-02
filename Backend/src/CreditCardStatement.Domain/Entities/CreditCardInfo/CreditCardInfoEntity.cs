using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using CreditCardStatement.Domain.Entities.Customer;

namespace CreditCardStatement.Domain.Entities.CreditCardInfo
{
    public class CreditCardInfoEntity
    {
        public int CreditCardInfoId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal ConfigurableInterestRate { get; set; }
        public decimal ConfigurableMinimumBalancePercentage { get; set; }
        public decimal BonifiableInterest { get; set; }
        public decimal MinimumFee { get; set; }
        public decimal PaymentWithInterest { get; set; }
        public CustomerEntity Customer { get; set; }
        public ICollection<CreditCardTransactionEntity> CreditCardTransactions { get; set; }
    }
}
