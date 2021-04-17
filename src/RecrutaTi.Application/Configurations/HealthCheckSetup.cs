using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RecrutaTi.Application.Configurations
{
    public static class HealthCheckSetup
    {
        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddSqlServer(
                    connectionString: configuration.GetSection("Databases:RecrutaTiDb:ConnectionString").Value,
                    name: configuration.GetSection("Databases:RecrutaTiDb:ServiceName").Value
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