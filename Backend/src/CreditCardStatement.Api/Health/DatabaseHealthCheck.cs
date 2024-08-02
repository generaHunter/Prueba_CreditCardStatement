using CreditCardStatement.Application.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CreditCardStatement.Api.Health
{
    /// <summary>
    /// HealthCheck para validar la conexion a la base de datos
    /// </summary>
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IDatabaseService _databaseService;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="databaseService"></param>
        public DatabaseHealthCheck(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// Metodo para agregar el HealthCheck para la conexion a la base de datos
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                var canConnect = await _databaseService.Customer.AnyAsync(cancellationToken);

                if (canConnect)
                {
                    return HealthCheckResult.Healthy("La conexión a la base de datos es exitosa.");
                }
                else
                {
                    return HealthCheckResult.Unhealthy("No se pudo obtener datos de la base de datos.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Ocurrió un error al intentar conectar con la base de datos.", ex);
            }
        }
    }
}
