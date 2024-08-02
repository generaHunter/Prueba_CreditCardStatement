using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using FluentValidation;

namespace CreditCardStatement.Application.Validators.CreditCardTransaction
{
    public class CreateCreditCardTransactionValidator: AbstractValidator<CommonCreditCardTransactionModel>
    {
        public CreateCreditCardTransactionValidator()
        {
            RuleFor(x => x.TransactionTypeId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.TransactionDate).NotNull().NotEmpty();
        }
    }
}
