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

        public void GetProfilesExtended()
        {
            var query = from user in _bddContext.Users
                        join profile in _bddContext.Profiles on user.ProfileId equals profile.Id
                        join professionalInfo in _bddContext.ProfessionalInfos on user.ProfessionalInfoId equals professionalInfo.Id
                        join contact in _bddContext.Contacts on user.ContactId equals contact.Id
                        select new { };
            var profilesExtended = query.ToList();
            foreach (var profile in profilesExtended) {
                //
            }
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
