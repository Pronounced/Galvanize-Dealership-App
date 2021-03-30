using System.Collections.Generic;
using dealership_api_dotnet.Services;
using dealership_app.Fake_Data;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace dealership_app.Controllers
{   
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService uService)
        {
            _usersService = uService;
        }

        [HttpGet]
        [Route("/getusers")]
        public ActionResult<List<User>> Get()
        {
            return _usersService.Get();
        }
    }
}