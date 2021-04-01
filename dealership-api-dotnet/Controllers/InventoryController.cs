using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Interfaces;

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
        public Car Post([FromBody]Car car)
        {
            _invRepository.Post(car);
            return car;
        }

        [HttpPut]
        [Route("/putcar")]
        public IActionResult Put([FromBody] Car car)
        {
            if(car == null)
            {
                return NotFound();
            }

            _invRepository.Put(car);

            return NoContent();
        }
    }
}