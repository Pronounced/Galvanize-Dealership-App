using System.Collections.Generic;
using System.Text.Json;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_app.Fake_Data;

namespace dealership_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Inventory.GetCars();
        }

        [HttpPost("addcar")]
        public void Post([FromBody]Car car)
        {
            Inventory.PostCar(car.year,car.make,car.model,car.seller,car.vin,car.isApproved,car.color);
        }

        [HttpPut("updatecar")]
        public void Put([FromBody] Car car)
        {
            Inventory.UpdateCar(car.isApproved, car.vin);
        }
    }
}