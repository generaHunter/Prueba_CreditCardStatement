using CreditCardStatement.Application.Database;
using CreditCardStatement.Domain.Entities.CreditCardInfo;
using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using CreditCardStatement.Domain.Entities.Customer;
using CreditCardStatement.Domain.Entities.TransactionType;
using CreditCardStatement.Persistence.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Persistence.Database
{
    public class DatabaseService: DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<CreditCardInfoEntity> CreditCardInfo { get; set;}

        public DbSet<TransactionTypeEntity> TransactionType { get; set; }

        public DbSet<CreditCardTransactionEntity> CreditCardTransaction { get; set; }

        public DbSet<TransactionResultEntity> TransactionResults { get; set; }

        public async Task<List<T>> ExecuteStoredProcedureAsync<T>(string storedProcedureName, params SqlParameter[] parameters) where T : class
        {
            var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
            var sql = $"EXEC {storedProcedureName} {parameterNames}";

            var result = await Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
            return result;
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TransactionResultEntity>().HasNoKey();
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new TransactionTypeConfiguration(modelBuilder.Entity<TransactionTypeEntity>());
            new CreditCardInfoConfiguration(modelBuilder.Entity<CreditCardInfoEntity>());
            new CreditCardTransactionConfiguration(modelBuilder.Entity<CreditCardTransactionEntity>());
        }
    }
}
