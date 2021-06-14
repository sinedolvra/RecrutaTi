using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using RecrutaTi.Application.Configurations;
using RecrutaTi.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;
using WarrantyService.Application.ConfigurationExtension;

namespace RecrutaTi.Application
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSettings(services);
            var jsonOptions = JsonSerializerExtensions.GetDefaultJsonSerializerSettings();
            services.ConfigureHealthChecks(Configuration);
            services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateFormatString = jsonOptions.DateFormatString;
                options.SerializerSettings.NullValueHandling = jsonOptions.NullValueHandling;
                options.SerializerSettings.ContractResolver = jsonOptions.ContractResolver;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
            
            ConfigureDatabases(services);
            services.ConfigureSwaggerSettings(Configuration);
            services.ConfigureSwaggerInfo();
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            var repositorySettings = Configuration.GetSection(RepositorySettings.SectionName).Get<RepositorySettings>();
            repositorySettings.SetInstance();
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .ConfigureHealthCheckEndpoints();

            app.ConfigureSwagger();
        }
    }
}