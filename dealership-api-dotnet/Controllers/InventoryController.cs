using System.Collections.Generic;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;

namespace dealership_app.Controllers
{
    [ApiController]  
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService iService)
        {
            _inventoryService = iService;
        }

        [HttpGet]
        [Route("/getcars")]
        public ActionResult<List<Car>> Get()
        {
            return _inventoryService.Get();
        }

        [HttpPost]
        [Route("/postcar")]
        public ActionResult<Car> Post([FromBody]Car car)
        {
            _inventoryService.Post(car);
            return CreatedAtRoute("/getcars", new { id = car._id.ToString()}, car);
        }

        [HttpPut]
        [Route("/putcar")]
        public IActionResult Put([FromBody] Car car)
        {
            if(car == null)
            {
                return NotFound();
            }

            _inventoryService.Put(car);

            return NoContent();
        }
    }
}