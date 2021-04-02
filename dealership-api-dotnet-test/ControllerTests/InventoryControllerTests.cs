using Xunit;
using Moq;
using dealership_api_dotnet.Controllers;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet_test
{
    public class InventoryControllerTests
    {
        [Fact]
        public void InventoryController_Should_Return_A_List()
        {
            //Arrange
            var mockRepository = new Mock<IServicesRepository<Car>>();
            mockRepository.Setup(repo => repo.Get()).Returns(GetTestInventory());
            var controller = new InventoryController(mockRepository.Object);
            //Act
            var result = controller.Get();
            //Assert
            Assert.IsType<List<Car>>(result);
        }

        private IEnumerable<Car> GetTestInventory()
        {
            var cars = new List<Car>();
            cars.Add(new Car(){
                year = 2001,
                make = "Honda",
                model = "Civic",
                vin = "22222222222222222",
                seller = "User1",
                isApproved = false,
                color = "blue",
                image = "imageURL"
            });
            cars.Add(new Car(){
                year = 2001,
                make = "Honda",
                model = "Civic",
                vin = "22222222222222222",
                seller = "User2",
                isApproved = false,
                color = "red",
                image = "imageURL"
            });
            cars.Add(new Car(){
                year = 2001,
                make = "Honda",
                model = "Civic",
                vin = "22222222222222222",
                seller = "User3",
                isApproved = false,
                color = "green",
                image = "imageURL"
            });
            return cars;
        }
  }
}
