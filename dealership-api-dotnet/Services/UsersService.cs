using System.Collections.Generic;
using System.Threading.Tasks;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;

namespace dealership_api_dotnet.Services
{
    public class UsersService : IServicesRepository<User>
    {
        private readonly IMongoCollection<User> _users;

        public UsersService(IDealershipDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<IEnumerable<User>> Get() =>
           _users.Find(user => true).ToList();

        public async Task Post(User user)
        {
           await _users.InsertOneAsync(user);
        }

        public async Task Put(User user){

        }

        public async Task Delete(User user){
            
        }
    }
}