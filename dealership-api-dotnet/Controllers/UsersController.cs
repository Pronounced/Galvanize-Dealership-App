using System.Collections.Generic;
using dealership_app.Fake_Data;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace dealership_app.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetEnumerable()
        {
            return Users.GetUsers();
        }
    }
}