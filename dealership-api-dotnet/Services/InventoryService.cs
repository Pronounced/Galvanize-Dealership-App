using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Services
{
    public class InventoryService : IServicesRepository<Car>
    {
        private readonly IMongoCollection<Car> _cars;

        public InventoryService(IDealershipDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Car>(settings.InventoryCollectionName);
        }

        public async Task<IEnumerable<Car>> Get() 
        {
            return _cars.Find(car => true).ToList();
        }

        public async Task Post(Car car){
            await _cars.InsertOneAsync(car);
        }
        public async Task Put(Car car){
           var found = _cars.Find(element => element.vin == car.vin).ToList();
           car._id = found[0]._id;
           car.__v = 0;
           await _cars.ReplaceOneAsync(element => element.vin == car.vin, car);
        }
           
        public async Task Delete (Car car){
            
        }
        
    }
}