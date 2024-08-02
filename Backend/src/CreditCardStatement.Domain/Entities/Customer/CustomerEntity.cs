using CreditCardStatement.Domain.Entities.CreditCardInfo;

namespace CreditCardStatement.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public ICollection<CreditCardInfoEntity> CreditCardInfos { get; set; }
    }
}
