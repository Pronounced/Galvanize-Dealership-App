using System.Collections.Generic;
using System.Text.Json;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_app.Fake_Data;

namespace dealership_app.Controllers
{
    [ApiController]  
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        [Route("/getcars")]
        public IEnumerable<Car> Get()
        {
            return Inventory.GetCars();
        }

        [HttpPost]
        [Route("/postcar")]
        public void Post([FromBody]Car car)
        {
            Inventory.PostCar(car.year,car.make,car.model,car.seller,car.vin,car.isApproved,car.color);
        }

        [HttpPut]
        [Route("/putcar")]
        public void Put([FromBody] Car car)
        {
            Inventory.UpdateCar(car.isApproved, car.vin);
        }
    }
}