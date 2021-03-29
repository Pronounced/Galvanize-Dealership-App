using System.Collections.Generic;
using System.Text.Json;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_app.Fake_Data;

namespace dealership_app.Controllers
{
    [ApiController]
    public class MessagerController : ControllerBase
    {
        [HttpGet]
        [Route("/getmessages")]
        public IEnumerable<Message> GetMessage()
        {
            return Messages.GetMessages();
        }

        [HttpPost]
        [Route("/postmessage")]
        public void Post([FromBody] Message message)
        {
            Messages.PostMessage(message.name, message.phoneNumber, message.email, message.message);
        }

       
    }
}