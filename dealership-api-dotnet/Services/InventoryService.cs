using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Services
{
    public class InventoryService : IServicesRepository<Car>
    {
        private readonly IMongoCollection<Car> _cars;

        public InventoryService(IOptions<IDealershipDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _cars = database.GetCollection<Car>(settings.Value.InventoryCollectionName);
        }

        public IEnumerable<Car> Get() 
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
            //Does Nothing
            await _cars.DeleteOneAsync(element => true);
        }
        
    }
}