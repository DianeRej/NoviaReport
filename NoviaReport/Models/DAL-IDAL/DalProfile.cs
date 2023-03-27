using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace NoviaReport.Models
{
    public class DalProfile : IDalProfile
    {
        private BddContext _bddContext;
        public DalProfile()
        {
            _bddContext = new BddContext();
            //_bddContext.InitializeDb();
        }
        //Méthode pour créer un Profile
        public int CreateProfile(string firstName, string lastName)
        {
            Profile profil = new Profile() { Firstname = firstName, Lastname = lastName };
            _bddContext.Profiles.Add(profil);
            _bddContext.SaveChanges();
            return profil.Id;
        }

        public void UpdateProfile(int id, string firstName, string lastName)
        {
            Profile profil = _bddContext.Profiles.Find(id);
            if (profil != null)
            {
                profil.Firstname = firstName;
                profil.Lastname = lastName;
                _bddContext.SaveChanges();
            }
        }

        public void UpdateProfile(Profile profile)
        {
            this._bddContext.Profiles.Update(profile);
            this._bddContext.SaveChanges();

        }

        public void DeleteProfile(int id)
        {
            Profile profileToDelete = _bddContext.Profiles.Find(id);
            _bddContext.Profiles.Remove(profileToDelete);
            _bddContext.SaveChanges();
        }

        public List<Profile> GetAllProfiles()
        {
            return _bddContext.Profiles.ToList();
        }


        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }
        
    }
}
