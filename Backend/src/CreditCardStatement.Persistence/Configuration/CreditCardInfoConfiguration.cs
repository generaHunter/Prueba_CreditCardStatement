using CreditCardStatement.Domain.Entities.CreditCardInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCardStatement.Persistence.Configuration
{
    public class CreditCardInfoConfiguration
    {
        public CreditCardInfoConfiguration(EntityTypeBuilder<CreditCardInfoEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CreditCardInfoId);
            entityBuilder.Property(x => x.CardNumber).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.CreditLimit).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.CurrentBalance).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.AvailableBalance).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.ConfigurableInterestRate).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.ConfigurableMinimumBalancePercentage).HasColumnType("decimal(5,2)").IsRequired();
            entityBuilder.Property(x => x.BonifiableInterest).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.MinimumFee).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(x => x.PaymentWithInterest).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.HasOne(x => x.Customer)
                          .WithMany(y => y.CreditCardInfos)
                          .HasForeignKey(x => x.CustomerId);
        }
    }
}
