using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

namespace RecrutaTi.Application.Configurations
{
    public static class SwaggerSetup
    {
        private static readonly SwaggerSettings Settings = SwaggerSettings.GetInstance();

        public static void ConfigureSwaggerSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SwaggerSettings.SectionName).Get<SwaggerSettings>();
            settings.SetInstance();
        }
        
        public static void ConfigureSwaggerInfo(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = Settings.Title,
                    Description = Settings.Description,
                    TermsOfService = new Uri(Settings.TermsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = Settings.ContactName,
                        Email = Settings.ContactEmail,
                        Url = new Uri(Settings.ContactUrl),
                    },
                    License = new OpenApiLicense
                    {
                        Name = Settings.LicenseName,
                        Url = new Uri(Settings.LicenseUrl),
                    }
                });
            }); 
        }
        
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SupportedSubmitMethods(new SubmitMethod[] { });
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
            });
        }
    }
}