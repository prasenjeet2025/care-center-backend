using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareCenterApi.Model
{
    public class Appointment
    {
        [BsonId]  // Specifies this is the MongoDB primary key (_id)
        [BsonRepresentation(BsonType.ObjectId)]  // Allows storing ObjectId as a string
        public string Id { get; set; } 

        [BsonElement("bookingName")]
        public string? BookingName { get; set; }

        [BsonElement("careType")]
        public string? CareType { get; set; }

        [BsonElement("hours")]
        public int Hours { get; set; }

        [BsonElement("pickDrop")]
        public bool PickDrop { get; set; }

        [BsonElement("fromDate")]
        public DateTime FromDate { get; set; }

        [BsonElement("toDate")]
        public DateTime ToDate { get; set; }

        [BsonElement("totalAmount")]
        public decimal TotalAmount { get; set; }

        
    }
}