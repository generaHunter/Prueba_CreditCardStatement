using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCardStatement.Persistence.Configuration
{
    public class CreditCardTransactionConfiguration
    {
        public CreditCardTransactionConfiguration(EntityTypeBuilder<CreditCardTransactionEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CreditCardTransactionId);
            entityBuilder.Property(x => x.TransactionDate).IsRequired();
            entityBuilder.Property(x => x.Amount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.Description).IsRequired();
            entityBuilder.HasOne(x => x.CreditCardInfo)
                          .WithMany(y => y.CreditCardTransactions)
                          .HasForeignKey(x => x.CreditCardInfoId);
            entityBuilder.HasOne(x => x.TransactionType)
                          .WithMany(y => y.CreditCardTransactions)
                          .HasForeignKey(x => x.TransactionTypeId);
        }
    }
}
