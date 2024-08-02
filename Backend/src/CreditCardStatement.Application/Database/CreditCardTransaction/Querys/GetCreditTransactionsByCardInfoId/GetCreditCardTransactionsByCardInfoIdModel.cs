using CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType;

namespace CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber
{
    public class GetCreditCardTransactionsByCardInfoIdModel
    {
        public int CreditCardTransactionId { get; set; }
        public int CreditCardInfoId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public GetAllTransactionsTypeModel TransactionType { get; set; }
    }
}
