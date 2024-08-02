using CreditCardStatement.Domain.Entities.CreditCardInfo;
using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using CreditCardStatement.Domain.Entities.Customer;
using CreditCardStatement.Domain.Entities.TransactionType;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database
{
    public interface IDatabaseService
    {
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<CreditCardInfoEntity> CreditCardInfo { get; set; }
        DbSet<TransactionTypeEntity> TransactionType { get; set; }
        DbSet<CreditCardTransactionEntity> CreditCardTransaction { get; set; }

        Task<List<T>> ExecuteStoredProcedureAsync<T>(string storedProcedureName, params SqlParameter[] parameters) where T : class;
        Task<bool> SaveAsync();
    }
}
