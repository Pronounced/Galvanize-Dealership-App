using Xunit;
using Moq;
using dealership_api_dotnet.Controllers;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet_test
{
    public class CarRulesControllerTests
    {
        [Fact]
        public void CarRulesController_Should_Return_A_List()
        {
            //Arrange
            var mockRepository = new Mock<IServicesRepository<CarRule>>();
            mockRepository.Setup(repo => repo.Get()).Returns(GetTestCarRules());
            var controller = new CarRulesController(mockRepository.Object);
            //Act
            var result = controller.Get();
            //Assert
            Assert.IsType<List<CarRule>>(result);
        }

        private IEnumerable<CarRule> GetTestCarRules()
        {
            var CarRules = new List<CarRule>();

            CarRules.Add(new CarRule(){
                name = "test",
                startYear = 2000,
                endYear = 2001,
                make = "honda",
                model = "civic",
                color = "blue"
            });

            return CarRules;
        }
  }
}
