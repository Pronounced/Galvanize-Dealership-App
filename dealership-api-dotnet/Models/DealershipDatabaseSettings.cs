namespace dealership_api_dotnet.Models
{
    public class DealershipDatabaseSettings : IDealershipDatabaseSettings
    {
        public string InventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDealershipDatabaseSettings
    {
        string InventoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}