using CreditCardStatement.Domain.Entities.CreditCardInfo;
using CreditCardStatement.Domain.Entities.TransactionType;

namespace CreditCardStatement.Domain.Entities.CreditCardTransaction
{
    public class CreditCardTransactionEntity
    {
        public int CreditCardTransactionId { get; set; }
        public int CreditCardInfoId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }

        // Navigation properties
        public CreditCardInfoEntity CreditCardInfo { get; set; }
        public TransactionTypeEntity TransactionType { get; set; }
    }
}
