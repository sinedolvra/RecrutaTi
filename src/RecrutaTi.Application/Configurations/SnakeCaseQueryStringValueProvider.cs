using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Serialization;

namespace RecrutaTi.Application.Configurations
{
    public class SnakeCaseQueryStringValueProvider : QueryStringValueProvider
    {
        private readonly SnakeCaseNamingStrategy namingStrategy = new SnakeCaseNamingStrategy();

        public SnakeCaseQueryStringValueProvider(BindingSource bindingSource, IQueryCollection values, CultureInfo culture)
            : base(bindingSource, values, culture)
        {
        }

        public override bool ContainsPrefix(string prefix)
        {
            return base.ContainsPrefix(namingStrategy.GetPropertyName(prefix, false));
        }

        public override ValueProviderResult GetValue(string key)
        {
            return base.GetValue(namingStrategy.GetPropertyName(key, false));
        }
    }
    
    public class SnakeCaseQueryStringValueProviderFactory : IValueProviderFactory
    {
        public SnakeCaseQueryStringValueProviderFactory()
        {
        }

        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var query = context.ActionContext.HttpContext.Request.Query;
            if (query?.Count > 0)
            {
                context.ValueProviders.Add(
                    new SnakeCaseQueryStringValueProvider(
                        BindingSource.Query,
                        context.ActionContext.HttpContext.Request.Query,
                        CultureInfo.InvariantCulture));
            }

            return Task.CompletedTask;
        }
    }
}