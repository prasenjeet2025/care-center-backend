using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareCenterApi.Model
{
    public class BookingDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

         [BsonElement("appointments")]
         public List<Appointment>? AppointmentDetails { get; set; }

        [BsonElement("petDetails")]
       public List<Pet>? PetDetails { get; set; }   

        [BsonElement("childDetails")]
         public List<Child>? ChildDetail { get; set; }

        [BsonElement("elderlyDetails")]
        public List<Elderly>? ElderDetail { get; set; }

        [BsonElement("specialDetails")]
        public List<SpecialNeed>? SpecialNeedDetail { get; set; }  

        
    
   
    
   
        
    }
}