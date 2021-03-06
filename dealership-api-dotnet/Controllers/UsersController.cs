using System.Collections.Generic;
using dealership_api_dotnet.Services;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dealership_api_dotnet.Interfaces;

namespace dealership_api_dotnet.Controllers
{   
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServicesRepository<User> _usersRepository;

        public UsersController(IServicesRepository<User> uService)
        {
            _usersRepository = uService;
        }

        [HttpGet]
        [Route("/getusers")]
        public IEnumerable<User> Get()
        {
            return _usersRepository.Get();
        }

        [HttpPost]
        [Route("/postuser")]
        public async Task Post([FromBody]User user)
        {
            await _usersRepository.Post(user);
        }
    }
}