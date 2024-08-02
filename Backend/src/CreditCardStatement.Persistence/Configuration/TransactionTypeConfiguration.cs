using CreditCardStatement.Domain.Entities.TransactionType;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCardStatement.Persistence.Configuration
{
    public class TransactionTypeConfiguration
    {
        public TransactionTypeConfiguration(EntityTypeBuilder<TransactionTypeEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.TransactionTypeId);
            entityBuilder.Property(x => x.TransactionTypeName).IsRequired().HasMaxLength(10);
        }
    }
}
