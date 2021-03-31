using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dealership_api_dotnet.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int __v { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime updatedate { get; set; }
    }
}