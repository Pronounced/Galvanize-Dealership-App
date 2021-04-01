using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;
using dealership_api_dotnet.Interfaces;

namespace dealership_api_dotnet.Controllers
{
    [ApiController]    
    public class CarRulesController : ControllerBase
    {
        private readonly IServicesRepository<CarRule> _rulesRepository;

        public CarRulesController(IServicesRepository<CarRule> crService)
        {
            _rulesRepository = crService;
        }

        [HttpGet]
        [Route("/getrules")]
        public IEnumerable<CarRule> GetCarRules()
        {
            return _rulesRepository.Get();
        }

        [HttpPost]
        [Route("/postrule")]
        public ActionResult<CarRule> Post([FromBody] CarRule carRule)
        {
            _rulesRepository.Post(carRule);
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

            _rulesRepository.Delete(carRule);

            return NoContent();
        }
    }
}