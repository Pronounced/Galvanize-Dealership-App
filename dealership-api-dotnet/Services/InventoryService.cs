using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Car> Get() 
        {
            return _cars.Find(car => true).ToList();
        }

        public Car Post(Car car){
            _cars.InsertOne(car);
            return car;
        }
        public void Put(Car car) =>
            _cars.ReplaceOne(element => element.vin == car.vin, car);

        public void Delete (Car car){
            
        }
        
    }
}