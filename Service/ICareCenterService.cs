using CareCenterApi.Model; 

namespace CareCenterApi.Service
{
    public interface ICareCenterService
    {
        void AddPet(Pet pet);
        Pet GetPetByName(string name);

         void AddChild(Child child);
        Child GetChildByName(string name);

         void AddElderly(Elderly elderly);
        Elderly GetElderlyByName(string name);

         void AddSpecial(SpecialNeed specialNeed);
        SpecialNeed GetSpecialByName(string name);
        void AddAppointment(Appointment appointment);
        public BookingDetail GetBookingDetail(string name, string careType);
        
    }
}