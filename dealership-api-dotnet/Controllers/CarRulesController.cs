using System.Collections.Generic;
using System.Text.Json;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_app.Fake_Data;

namespace dealership_app.Controllers
{
    [ApiController]    
    public class CarRulesController : ControllerBase
    {
        [HttpGet]
        [Route("/getrules")]
        public IEnumerable<CarRule> GetCarRules()
        {
            return CarRules.GetCarRules();
        }

        [HttpPost]
        [Route("/postrule")]
        public void Post([FromBody] CarRule carRule)
        {
            CarRules.PostCarRule(carRule.name,carRule.startYear,carRule.endYear,carRule.make,carRule.model,carRule.color);
        }

        [HttpDelete]
        [Route("/deleterule")]
        public void Delete([FromBody] CarRule carRule)
        {
            CarRules.DeleteCarRule(carRule.name);
        }
    }
}