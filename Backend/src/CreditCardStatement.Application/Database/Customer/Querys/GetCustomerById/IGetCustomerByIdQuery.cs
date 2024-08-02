using CreditCardStatement.Application.Database.Customer.CommonModel;

namespace CreditCardStatement.Application.Database.Customer.Querys.GetCustomerById
{
    public interface IGetCustomerByIdQuery
    {
        Task<CommonCustomerModel> Execute(int CustomerId);
    }
}
