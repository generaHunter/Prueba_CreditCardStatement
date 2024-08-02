namespace CreditCardStatement.FrontMVC.Models.CreditCardInfo
{
    public class CommonCreditCardInfoViewModel
    {
        public int CustomerId { get; set; }
        public List<CreditCardInfoViewModel>? creditCardInfos { get; set; }
    }
}
