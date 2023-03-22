using System;
using System.Collections.Generic;

namespace NoviaReport.Models
{
    public interface IDalProfile : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateProfile(string firstName, string lastName);
        void UpdateProfile(int id, string firstName, string lastName);
        void UpdateProfile(Profile profile);

        public int CreateUser(string login, string password);
        public int CreateUser(User user);

        public int CreateContact(string personalMail, int personalPhone, string proMail,
           int proPhone, Adress adress, int adressId);

        public int CreateAdress(string num, string street, int postalCode, string city);

        void UpdateProfile(int id, string firstName ,string lastName);
        void DeleteProfile(int id);

        List<Profile> GetAllProfiles();
    }
}