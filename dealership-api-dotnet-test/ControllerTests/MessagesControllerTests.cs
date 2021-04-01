using Xunit;
using Moq;
using dealership_api_dotnet.Controllers;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet_test
{
    public class MessagesControllerTests
    {
        [Fact]
        public void MessagesController_Should_Return_A_List()
        {
            //Arrange
            var mockRepository = new Mock<IServicesRepository<Message>>();
            mockRepository.Setup(repo => repo.Get()).Returns(GetTestMessages());
            var controller = new MessagerController(mockRepository.Object);
            //Act
            var result = controller.Get();
            //Assert
            Assert.IsType<Task<IEnumerable<Message>>>(result);
        }

        private async Task<IEnumerable<Message>> GetTestMessages()
        {
            var messages = new List<Message>();

            messages.Add(new Message(){
                name = "test test",
                phoneNumber = "123123123123",
                email = "adsfsadf@asdfsd.com",
                message = "asdfasdfasdfasdfasdfasdfksld;flajsd;fasjdf;asldkfjas;ldfkjasld"
            });
            messages.Add(new Message(){
                name = "test test2",
                phoneNumber = "123123123123",
                email = "adsfsadf@asdfsd.com",
                message = "asdfasdfasdfasdfasdfasdfksld;flajsd;fasjdf;asldkfjas;ldfkjasld"
            });
            messages.Add(new Message(){
                name = "test test3",
                phoneNumber = "123123123123",
                email = "adsfsadf@asdfsd.com",
                message = "asdfasdfasdfasdfasdfasdfksld;flajsd;fasjdf;asldkfjas;ldfkjasld"
            });


            return messages;
        }
  }
}
