using Microsoft.Extensions.DependencyInjection;

namespace CreditCardStatement.Common
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
