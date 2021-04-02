using System.Collections.Generic;
using dealership_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using dealership_api_dotnet.Services;
using dealership_api_dotnet.Interfaces;
using System.Threading.Tasks;

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
        public IEnumerable<CarRule> Get()
        {
            return _rulesRepository.Get();
        }

        [HttpPost]
        [Route("/postrule")]
        public async Task Post([FromBody] CarRule carRule)
        {
            await _rulesRepository.Post(carRule);
        }

        [HttpDelete]
        [Route("/deleterule")]
        public async Task Delete([FromBody] CarRule carRule)
        {
            await _rulesRepository.Delete(carRule);
        }
    }
}