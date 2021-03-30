using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dealership_app.Models
{
    public class CarRule
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int __v { get; set; }
        public string name { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color {get; set;}

    }
}