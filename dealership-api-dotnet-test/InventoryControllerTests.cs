using Xunit;
using Moq;
using dealership_api_dotnet.Controllers;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using System.Collections.Generic;

namespace dealership_api_dotnet_test
{
    public class InventoryControllerTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var mockRepository = new Mock<IServicesRepository<Car>>();
            mockRepository.Setup(repo => repo.Get()).Returns(GetTestInventory());
            var controller = new InventoryController(mockRepository.Object);
            //Act
            var result = controller.Get();
            //Assert
            Assert.NotEmpty(result);
        }

        private IEnumerable<Car> GetTestInventory()
        {
            var cars = new List<Car>();
            cars.Add(new Car(){color = "blue"});
            cars.Add(new Car(){color = "red"});
            cars.Add(new Car(){color = "green"});

            return cars;
        }
  }
}
