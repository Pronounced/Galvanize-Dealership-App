using Xunit;
using Moq;
using dealership_api_dotnet.Controllers;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet_test
{
    public class UsersControllerTests
    {
        [Fact]
        public void UsersController_Should_Return_A_List()
        {
            //Arrange
            var mockRepository = new Mock<IServicesRepository<User>>();
            mockRepository.Setup(repo => repo.Get()).Returns(GetTestUsers());
            var controller = new UsersController(mockRepository.Object);
            //Act
            var result = controller.Get();
            //Assert
            Assert.IsType<Task<IEnumerable<User>>>(result);
        }

        private async Task<IEnumerable<User>> GetTestUsers()
        {
            var users = new List<User>();
            users.Add(new User(){
                username = "1",
                email = "blah",
                password = "'test'",
                isAdmin = false
            });
            users.Add(new User(){
                username = "2",
                email = "blah",
                password = "'test'",
                isAdmin = false
            });
            users.Add(new User(){
                username = "4",
                email = "blah",
                password = "'test'",
                isAdmin = false
            });

            return users;
        }
  }
}
