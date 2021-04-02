using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Interfaces;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Controllers
{
    [ApiController]  
    public class InventoryController : ControllerBase
    {
        private readonly IServicesRepository<Car> _invRepository;

        public InventoryController(IServicesRepository<Car> iService)
        {
            _invRepository = iService;
        }

        [HttpGet]
        [Route("/getcars")]
        public IEnumerable<Car> Get()
        {
            return _invRepository.Get();
        }

        [HttpPost]
        [Route("/postcar")]
        public async Task Post([FromBody]Car car)
        {
            await _invRepository.Post(car);
        }

        [HttpPut]
        [Route("/putcar")]
        public async Task Put([FromBody] Car car)
        {
            await _invRepository.Put(car);
        }
    }
}