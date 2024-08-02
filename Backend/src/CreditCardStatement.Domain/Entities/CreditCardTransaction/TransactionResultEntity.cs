namespace CreditCardStatement.Domain.Entities.CreditCardTransaction
{
    public class TransactionResultEntity
    {
        public int SUCCESS { get; set; }
        public int CreditCardTransactionId { get; set; }
        public string MESSAGE { get; set; }
    }
}
