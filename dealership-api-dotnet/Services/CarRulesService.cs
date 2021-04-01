using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Services
{
    public class CarRulesService : IServicesRepository<CarRule>
    {
        private readonly IMongoCollection<CarRule> _rules;

        public CarRulesService(IDealershipDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _rules = database.GetCollection<CarRule>(settings.RulesCollectionName);        
        }

        public async Task<IEnumerable<CarRule>> Get() =>
            _rules.Find(rule => true).ToList();

        public async Task Post(CarRule rule){
            await _rules.InsertOneAsync(rule);
        }
        public async Task Delete(CarRule rule){
           await _rules.DeleteOneAsync(element => element._id == rule._id);
        }

        public async Task Put(CarRule rule){
    
        }
    }
}