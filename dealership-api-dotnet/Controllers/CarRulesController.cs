using System.Collections.Generic;
using System.Text.Json;
using dealership_app.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_app.Fake_Data;

namespace dealership_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRulesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CarRule> GetCarRules()
        {
            return CarRules.GetCarRules();
        }

        [HttpPost("addcarrule")]
        public void Post([FromBody] CarRule carRule)
        {
            CarRules.PostCarRule(carRule.name,carRule.startYear,carRule.endYear,carRule.make,carRule.model,carRule.color);
        }

        [HttpDelete("deletecarrule")]
        public void Delete([FromBody] CarRule carRule)
        {
            CarRules.DeleteCarRule(carRule.name);
        }
    }
}