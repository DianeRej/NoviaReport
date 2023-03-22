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

        void DeleteProfile(int id);

        List<Profile> GetAllProfiles();
    }
}