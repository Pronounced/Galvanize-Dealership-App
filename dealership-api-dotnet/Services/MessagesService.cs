using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealership_api_dotnet.Services
{
    public class MessagesService : IServicesRepository<Message>
    {
        private readonly IMongoCollection<Message> _messages;

        public MessagesService(IOptions<IDealershipDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _messages = database.GetCollection<Message>(settings.Value.MessagesCollectionName);
        }

        public IEnumerable<Message> Get() =>
            _messages.Find(message => true).ToList();

        public async Task Post(Message message){
            await _messages.InsertOneAsync(message);
        }

        public async Task Put(Message message){
            //Does Nothing
            await _messages.ReplaceOneAsync(c => true, null);
        }
        public async Task Delete(Message message){
            //Does Nothing
            await _messages.DeleteOneAsync(element => true);
        }
    }
}