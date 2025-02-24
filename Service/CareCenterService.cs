using System;
using System.Collections.Generic;
using MongoDB.Driver;
using CareCenterApi.Model;

namespace CareCenterApi.Service
{
    public class CareCenterService : ICareCenterService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Pet>? _petCollection;
        private readonly IMongoCollection<Child>? _childCollection;
        private readonly IMongoCollection<Elderly>? _elderlyCollection;
        private readonly IMongoCollection<SpecialNeed>? _specialCollection;


        public CareCenterService(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("CareCenterDB");
            _petCollection = _database.GetCollection<Pet>("Pets");
            _childCollection = _database.GetCollection<Child>("Children");
            _elderlyCollection = _database.GetCollection<Elderly>("Elders");
            _specialCollection = _database.GetCollection<SpecialNeed>("SpecialNeeds");
        }
       
        public void AddPet(Pet pet)
        {
            if (_petCollection != null)
            {
                _petCollection.InsertOne(pet);
            }
            else
            {
                throw new InvalidOperationException("Pet collection is not initialized.");
            }
        }
        public Pet GetPetByName(string name)
        {
            
            var collection = _database.GetCollection<Pet>("Pets");
            var filter = Builders<Pet>.Filter.Eq(p => p.Name, name);
            return collection.Find(filter).FirstOrDefault();
        }

        public void AddChild(Child child)
        {
            if (_childCollection != null)
            {
                _childCollection.InsertOne(child);
            }
            else
            {
                throw new InvalidOperationException("Child collection is not initialized.");
            }
        }
        public Child GetChildByName(string name)
        {
            
            var collection = _database.GetCollection<Child>("Children");
            var filter = Builders<Child>.Filter.Eq(c => c.Name, name);
            return collection.Find(filter).FirstOrDefault();
        }

         public void AddElderly(Elderly elderly)
        {
            if (_elderlyCollection != null)
            {
                _elderlyCollection.InsertOne(elderly);
            }
            else
            {
                throw new InvalidOperationException("Elderly collection is not initialized.");
            }
        }
        public Elderly GetElderlyByName(string name)
        {           
            var collection = _database.GetCollection<Elderly>("Elderly");
            var filter = Builders<Elderly>.Filter.Eq(e => e.Name, name);
            return collection.Find(filter).FirstOrDefault();
        }

          public void AddSpecial(SpecialNeed specialNeed)
        {
            if (_specialCollection != null)
            {
                _specialCollection.InsertOne(specialNeed);
            }
            else
            {
                throw new InvalidOperationException("SpecialNeed collection is not initialized.");
            }
        }
        public SpecialNeed GetSpecialByName(string name)
        {
           
            var collection = _database.GetCollection<SpecialNeed>("SpecialNeeds");
            var filter = Builders<SpecialNeed>.Filter.Eq(s => s.Name, name);
            return collection.Find(filter).FirstOrDefault();
        }
        public void AddAppointment(Appointment appointment)
        {
            var collection = _database.GetCollection<Appointment>("Appointments");
            collection.InsertOne(appointment);
        }

        public BookingDetail GetBookingDetail(string name, string careType)
        {
            var collection = _database.GetCollection<Appointment>("Appointments");
            var filter = Builders<Appointment>.Filter.Eq(a => a.BookingName, name) & Builders<Appointment>.Filter.Eq(a => a.CareType, careType);
            //return collection.Find(filter).ToList();

            var appointments = collection.Find(filter).ToList();
            var bookingDetail = new BookingDetail
            {
                AppointmentDetails = appointments
            };

            if (careType == "Pet")
            {
                var petFilter = Builders<Pet>.Filter.Eq(p => p.Name, name);
                bookingDetail.PetDetails = _petCollection.Find(petFilter).ToList();
            }
            else if (careType == "Child")
            {
                var childFilter = Builders<Child>.Filter.Eq(c => c.Name, name);
                bookingDetail.ChildDetail = _childCollection.Find(childFilter).ToList();
            }
            else if (careType == "Elderly")
            {
                var elderlyFilter = Builders<Elderly>.Filter.Eq(e => e.Name, name);
                bookingDetail.ElderDetail = _elderlyCollection.Find(elderlyFilter).ToList();
            }
            else if (careType == "SpecialNeed")
            {
                var specialFilter = Builders<SpecialNeed>.Filter.Eq(s => s.Name, name);
                bookingDetail.SpecialNeedDetail = _specialCollection.Find(specialFilter).ToList();
            }

            return bookingDetail;
            
           
        }
    }
}