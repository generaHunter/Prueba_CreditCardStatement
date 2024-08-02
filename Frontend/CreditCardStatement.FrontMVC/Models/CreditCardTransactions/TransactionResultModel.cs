namespace CreditCardStatement.FrontMVC.Models.CreditCardTransactions
{
    public class TransactionResultModel
    {
            public int SUCCESS { get; set; } = 0;
            public int CreditCardTransactionId { get; set; } = 0;
            public string MESSAGE { get; set; } = string.Empty;
    }
}
