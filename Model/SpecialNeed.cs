using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareCenterApi.Model
{
    public class SpecialNeed
    {
        [BsonId]  // Specifies this is the MongoDB primary key (_id)
        [BsonRepresentation(BsonType.ObjectId)]  // Allows storing ObjectId as a string
        public string Id { get; set; } 

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("photo")]
        public string Photo { get; set; }

        [BsonElement("dependentName")]
        public string DependentName { get; set; }        

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("contactNumber")]
        public string ContactNumber { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("perHourCharge")]
        public decimal PerHourCharge { get; set; }
    }
}