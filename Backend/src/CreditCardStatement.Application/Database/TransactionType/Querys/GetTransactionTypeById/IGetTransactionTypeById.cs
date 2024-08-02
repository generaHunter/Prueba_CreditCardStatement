namespace CreditCardStatement.Application.Database.TransactionType.Querys.GetTransactionTypeById
{
    public interface IGetTransactionTypeById
    {
        Task<GetTransactionTypeByIdModel> Execute(int id);
    }
}
