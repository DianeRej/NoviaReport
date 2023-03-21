using System;
using System.Collections.Generic;

namespace NoviaReport.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateProfile(string firstName ,string lastName);

        void UpdateProfile(int id, string firstName ,string lastName);
        void UpdateProfile(Profile profile);
        public int CreateUser(string login, string password);
        public int CreateUser(User user);
        public int CreateContact(string personalMail, string personalPhone, string proMail,
           string proPhone, Adress adress, int adressId);
        public int CreateAdress(int num, string street, int postalCode, string city);


        List<Profile> GetAllProfiles();
    }
}

