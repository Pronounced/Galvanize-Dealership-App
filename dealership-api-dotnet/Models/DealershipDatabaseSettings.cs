namespace dealership_api_dotnet.Models
{
    public class DealershipDatabaseSettings : IDealershipDatabaseSettings
    {
        public string RulesCollectionName { get; set; }
        public string MessagesCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string InventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDealershipDatabaseSettings
    {
        string RulesCollectionName { get; set; }
        string MessagesCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string InventoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}