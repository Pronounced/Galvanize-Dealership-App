using Xunit;
using Moq;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using dealership_api_dotnet.Services;

namespace dealership_api_dotnet_test
{
    
    public class InventoryServiceTests
    {
        private Mock<IOptions<DealershipDatabaseSettings>> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;

        public InventoryServiceTests()
        {
            _mockClient = new Mock<IMongoClient>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockOptions = new Mock<IOptions<DealershipDatabaseSettings>>();
        }

        [Fact]
        public void TestName()
        {
            //Given
            var settings = new DealershipDatabaseSettings()
            {
                InventoryCollectionName = "testInventory",
                DatabaseName = "mockDb",
                ConnectionString = "mongodb://monkConnection"
            };
            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
                .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);
            //When
            var service = new InventoryService(_mockOptions.Object); 
            //Then
            Assert.NotNull(service);
        }
    }
}