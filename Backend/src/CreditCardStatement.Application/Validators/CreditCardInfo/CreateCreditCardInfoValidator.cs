using CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo;
using FluentValidation;

namespace CreditCardStatement.Application.Validators.CreditCardInfo
{
    public class CreateCreditCardInfoValidator: AbstractValidator<CreateCreditCardInfoModel>
    {
        public CreateCreditCardInfoValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.CardNumber).NotNull().NotEmpty().MaximumLength(20).MinimumLength(16);
            RuleFor(x => x.CreditLimit).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.AvailableBalance).NotEmpty().NotEmpty().GreaterThan(0);
            RuleFor(x => x.ConfigurableInterestRate).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.ConfigurableMinimumBalancePercentage).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
