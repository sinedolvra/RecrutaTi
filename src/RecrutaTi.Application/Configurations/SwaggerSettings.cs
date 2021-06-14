namespace RecrutaTi.Application.Configurations
{
    public class SwaggerSettings
    {
        public const string SectionName = "SwaggerSettings";
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactUrl { get; set; }
        public string LicenseName { get; set; }
        public string LicenseUrl { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public string Title { get; set; }
        public string DeprecationMessage { get; set; }

        private static SwaggerSettings _instance;

        public static SwaggerSettings GetInstance()
        {
            return _instance;
        }

        protected internal void SetInstance()
        {
            _instance = this;
        }
    }
}