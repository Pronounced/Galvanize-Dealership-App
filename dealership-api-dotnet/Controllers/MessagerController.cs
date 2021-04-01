using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;
using System.Threading.Tasks;
using dealership_api_dotnet.Interfaces;

namespace dealership_api_dotnet.Controllers
{
    [ApiController]
    public class MessagerController : ControllerBase
    {
        private readonly IServicesRepository<Message> _messagesRepository;

        public MessagerController(IServicesRepository<Message> mService)
        {
            _messagesRepository = mService;
        }

        [HttpGet]
        [Route("/getmessages")]
        public async Task<IEnumerable<Message>> Get()
        {
            return await _messagesRepository.Get();
        }

        [HttpPost]
        [Route("/postmessage")]
        public async Task Post([FromBody] Message message)
        {
            await _messagesRepository.Post(message);
        }
    }
}