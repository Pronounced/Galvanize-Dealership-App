using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dealership_api_dotnet.Models
{
    public class CarRule
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int __v { get; set; }
        public string name { get; set; }
        public int startYear { get; set; }
        public int endYear { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color {get; set;}

    }
}