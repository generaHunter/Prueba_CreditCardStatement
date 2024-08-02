namespace CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType
{
    public interface IGetAllTransactionsType
    {
        Task<List<GetAllTransactionsTypeModel>> Execute();
    }
}
