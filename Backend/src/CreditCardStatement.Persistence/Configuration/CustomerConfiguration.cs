using CreditCardStatement.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCardStatement.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CustomerId);
            entityBuilder.Property(x => x.CustomerName).IsRequired();
        }
    }
}
