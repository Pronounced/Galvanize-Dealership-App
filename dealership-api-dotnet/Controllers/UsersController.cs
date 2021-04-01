using System.Collections.Generic;
using dealership_api_dotnet.Services;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dealership_api_dotnet.Controllers
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
        public IEnumerable<User> Get()
        {
            return _usersService.Get();
        }
    }
}