using CreditCardStatement.FrontMVC.Models.TransactionsType;

namespace CreditCardStatement.FrontMVC.Models.CreditCardTransactions
{
    public class CreditCardTransactionViewModel
    {

        public int CreditCardInfoId { get; set; }

        public int CustomerId { get; set; } = 0;
        public string CreditCardNumber { get; set; } = string.Empty;
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public TransactionTypeViewModel? TransactionType { get; set; }
    }
}
