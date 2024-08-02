using CreditCardStatement.Application.Database.Customer.CommonModel;

namespace CreditCardStatement.Application.Database.Customer.Querys.GetAllCustomers
{
    public interface IGetAllCustomerQuery
    {
        Task<List<CommonCustomerModel>> Execute();
    }
}
