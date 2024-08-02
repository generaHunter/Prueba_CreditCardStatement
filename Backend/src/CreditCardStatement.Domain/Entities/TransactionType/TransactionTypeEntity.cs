using CreditCardStatement.Domain.Entities.CreditCardTransaction;

namespace CreditCardStatement.Domain.Entities.TransactionType
{
    public class TransactionTypeEntity
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }

        // Navigation property
        public ICollection<CreditCardTransactionEntity> CreditCardTransactions { get; set; }
    }
}
