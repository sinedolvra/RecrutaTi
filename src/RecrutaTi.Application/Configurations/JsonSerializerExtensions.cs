using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace WarrantyService.Application.ConfigurationExtension
{
    public static class JsonSerializerExtensions
    {
        public static JsonSerializerSettings GetDefaultJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss",
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            
            settings.Converters.Add(new StringEnumConverter());
            
            return settings;
        }
    }
}