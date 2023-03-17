using System;
using System.Collections.Generic;

namespace NoviaReport.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateProfile(string firstName ,string lastName);

        void UpdateProfile(int id, string firstName ,string lastName);

        List<Profile> GetAllProfiles();
    }
}

