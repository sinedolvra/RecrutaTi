using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RecrutaTi.Repository;

namespace RecrutaTi.Application.Configurations
{
    public static class HealthCheckSetup
    {
        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddSqlServer(
                    connectionString: RepositorySettings.Instance.RecrutaTiDbSettings.ConnectionString,
                    name: RepositorySettings.Instance.RecrutaTiDbSettings.ServiceName
                );
        }

        public static void ConfigureHealthCheckEndpoints(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = CustomHealthCheckResponse.WriteHealthCheckResponse
            });
        }
    }
}