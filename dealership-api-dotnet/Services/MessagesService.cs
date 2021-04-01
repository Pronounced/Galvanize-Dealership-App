using dealership_api_dotnet.Interfaces;
using dealership_api_dotnet.Models;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public IEnumerable<Message> Get() =>
            _messages.Find(message => true).ToList();

        public Message Post(Message message){
            _messages.InsertOne(message);
            return message;
        }

        public void Put(Message message){

        }
        public void Delete(Message message){
            
        }
    }
}