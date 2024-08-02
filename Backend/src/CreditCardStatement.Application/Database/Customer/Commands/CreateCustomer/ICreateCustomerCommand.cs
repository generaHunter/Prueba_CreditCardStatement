using CreditCardStatement.Application.Database.Customer.CommonModel;

namespace CreditCardStatement.Application.Database.Customer.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        Task<CommonCustomerModel> Execute(CommonCustomerModel model);
    }
}
