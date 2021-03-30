using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dealership_app.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int __v { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}