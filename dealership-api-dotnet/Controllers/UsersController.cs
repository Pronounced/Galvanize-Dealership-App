using System.Collections.Generic;
using dealership_app.Fake_Data;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace dealership_app.Controllers
{
    
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("/getusers")]
        public IEnumerable<User> GetEnumerable()
        {
            return Users.GetUsers();
        }
    }
}