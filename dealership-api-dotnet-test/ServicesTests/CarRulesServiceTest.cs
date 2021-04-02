using dealership_api_dotnet.Models;
using dealership_api_dotnet.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace dealership_api_dotnet_test
{
    public class CarRulesServiceTest
    {
        private Mock<IOptions<DealershipDatabaseSettings>> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;

        public CarRulesServiceTest()
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
                RulesCollectionName = "testCarRules",
                DatabaseName = "mockDb",
                ConnectionString = "mongodb://monkConnection"
            };
            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
                .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);
            //When
            var service = new CarRulesService(_mockOptions.Object); 
            //Then
            Assert.NotNull(service);
        }
    }
}