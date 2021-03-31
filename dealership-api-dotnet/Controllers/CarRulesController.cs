using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;

namespace dealership_api_dotnet.Controllers
{
    [ApiController]    
    public class CarRulesController : ControllerBase
    {
        private readonly CarRulesService _rulesService;

        public CarRulesController(CarRulesService crService)
        {
            _rulesService = crService;
        }

        [HttpGet]
        [Route("/getrules")]
        public ActionResult<List<CarRule>> GetCarRules()
        {
            return _rulesService.Get();
        }

        [HttpPost]
        [Route("/postrule")]
        public ActionResult<CarRule> Post([FromBody] CarRule carRule)
        {
            _rulesService.Post(carRule);
            return CreatedAtRoute("/getrules", new { id = carRule._id.ToString()}, carRule);
        }

        [HttpDelete]
        [Route("/deleterule")]
        public IActionResult Delete([FromBody] CarRule carRule)
        {
            if(carRule == null)
            {
                return NotFound();
            }

            _rulesService.Delete(carRule);

            return NoContent();
        }
    }
}