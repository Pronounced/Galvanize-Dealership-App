using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;

namespace dealership_api_dotnet.Controllers
{
    [ApiController]
    public class MessagerController : ControllerBase
    {
        private readonly MessagesService _messagesService;

        public MessagerController(MessagesService mService)
        {
            _messagesService = mService;
        }

        [HttpGet]
        [Route("/getmessages")]
        public ActionResult<List<Message>> Get()
        {
            return _messagesService.Get();
        }

        [HttpPost]
        [Route("/postmessage")]
        public ActionResult<Message> Post([FromBody] Message message)
        {
            _messagesService.Post(message);
            return CreatedAtRoute("/getmessages", new {id = message._id.ToString()}, message);
        }
    }
}