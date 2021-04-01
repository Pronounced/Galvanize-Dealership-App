using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Services
{
    public class MessagesService : IServicesRepository<Message>
    {
        private readonly IMongoCollection<Message> _messages;

        public MessagesService(IDealershipDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessagesCollectionName);
        }

        public async Task<IEnumerable<Message>> Get() =>
            _messages.Find(message => true).ToList();

        public async Task Post(Message message){
            await _messages.InsertOneAsync(message);
        }

        public async Task Put(Message message){

        }
        public async Task Delete(Message message){
            
        }
    }
}