using CreditCardStatement.Application.Database.Customer.CommonModel;
using FluentValidation;

namespace CreditCardStatement.Application.Validators.Customer
{
    public class CreateCustomerValidator: AbstractValidator<CommonCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotNull().WithMessage("El campo no puede ser nulo")
                .NotEmpty().WithMessage("El campo no puede ser vacio")
                .MaximumLength(150).WithMessage("El maximo numero de caracteres es 150");
        }
    }
}
