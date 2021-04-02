using System.Collections.Generic;
using System.Threading.Tasks;
using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dealership_api_dotnet.Services
{
    public class UsersService : IServicesRepository<User>
    {
        private readonly IMongoCollection<User> _users;

        public UsersService(IOptions<IDealershipDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _users = database.GetCollection<User>(settings.Value.UsersCollectionName);
        }

        public IEnumerable<User> Get() =>
           _users.Find(user => true).ToList();

        public async Task Post(User user)
        {
           await _users.InsertOneAsync(user);
        }

        public async Task Put(User user){
            //Does Nothing
            await _users.ReplaceOneAsync(c => true, null);
        }

        public async Task Delete(User user){
            //Does Nothing
            await _users.DeleteOneAsync(element => true);
        }
    }
}