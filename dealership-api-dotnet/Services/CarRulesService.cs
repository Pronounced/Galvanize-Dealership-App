using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public IEnumerable<CarRule> Get() =>
            _rules.Find(rule => true).ToList();

        public CarRule Post(CarRule rule){
            _rules.InsertOne(rule);
            return rule;
        }
        public void Delete(CarRule rule){
            _rules.DeleteOne(element => element._id == rule._id);
        }

        public void Put(CarRule rule){
            
        }
    }
}