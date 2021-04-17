namespace RecrutaTi.Domain.Settings
{
    public class RepositorySettings
    {
        public const string SectionName = "RepositorySettings";
        public RecrutaTiDbSettings RecrutaTiDbSettings { get; set; }

        public static RepositorySettings Instance;

        public void SetInstance()
        {
            Instance = this;
        }
    }

    public class RecrutaTiDbSettings
    {
        public string ServiceName { get; set; }
        public string ConnectionString { get; set; }
    }
}