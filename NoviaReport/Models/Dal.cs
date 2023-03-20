using System.Collections.Generic;
using System.Linq;

namespace NoviaReport.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
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

        public int CreateUser(string login, string password)
        {
            User user = new User() { Login = login, Password = password };
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }

        public int CreateUser(User user)
        {
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }

        public int CreateContact(string personalMail, string personalPhone, string proMail,
            string proPhone, Adress adress, int adressId)
        {
            Contact contact = new Contact() { PersonalMail = personalMail , PersonalPhone = personalPhone, ProMail = proMail, ProPhone = proPhone, 
            Adress = adress, AdressId = adressId};
            _bddContext.Contacts.Add(contact);
            _bddContext.SaveChanges();
            return contact.Id;
        }

        public int CreateAdress(int num, string street, int postalCode, string city)
        {
            Adress adress = new Adress() { Num = num, Street = street, PostalCode = postalCode, City = city};
            _bddContext.Adresses.Add(adress);
            _bddContext.SaveChanges();
            return adress.Id;
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

        public List<Profile> GetAllProfiles()
        {
            return _bddContext.Profiles.ToList();
        }
    }
}
