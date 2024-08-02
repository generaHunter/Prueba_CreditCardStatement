using CreditCardStatement.Application.Database;
using CreditCardStatement.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CreditCardStatement.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersitence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(options =>
            options.UseSqlServer(configuration["SQLConnectionStrings"])
            );

            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}
