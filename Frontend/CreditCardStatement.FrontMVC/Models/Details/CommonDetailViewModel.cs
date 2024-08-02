using CreditCardStatement.FrontMVC.Models.CreditCardInfo;
using CreditCardStatement.FrontMVC.Models.CreditCardTransactions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditCardStatement.FrontMVC.Models.Details
{
    public class CommonDetailViewModel
    {
        public CreditCardInfoViewModel CreditCardInfo { get; set; }

        public IEnumerable<SelectListItem> TransactionTypes { get; set; }

        public List<CreditCardTransactionViewModel> CreditCardTransactions { get; set; }
    }
}
