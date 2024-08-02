using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CreditCardStatement.Api
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Credit Card Transactions API",
                        Description = "Api para la administracion de movimientos de tarjeta de creditos"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}
