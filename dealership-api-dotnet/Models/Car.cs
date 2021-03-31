using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace dealership_api_dotnet.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string vin { get; set; }
        public string seller { get; set; }
        public bool isApproved { get; set; }
        public string color {get; set;}
        public string image { get; set; }
        public int __v { get; set; }
    }
}