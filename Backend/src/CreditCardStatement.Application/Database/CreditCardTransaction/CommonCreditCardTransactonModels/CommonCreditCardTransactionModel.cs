namespace CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels
{
    public class CommonCreditCardTransactionModel
    {
        public int CreditCardTransactionId { get; set; } = 0;
        public int CreditCardInfoId { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
