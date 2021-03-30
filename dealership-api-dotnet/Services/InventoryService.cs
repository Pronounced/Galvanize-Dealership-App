using dealership_app.Models;
using MongoDB.Driver;
using dealership_api_dotnet.Models;
using System.Collections.Generic;

namespace dealership_api_dotnet.Services
{
    public class InventoryService
    {
        private readonly IMongoCollection<Car> _cars;

        public InventoryService(IDealershipDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Car>(settings.InventoryCollectionName);
        }

        public List<Car> Get() =>
            _cars.Find(car => true).ToList();

        public Car Post(Car car){
            _cars.InsertOne(car);
            return car;
        }

        public void Put(Car car) =>
            _cars.ReplaceOne(element => element.vin == car.vin, car);
        
    }
}