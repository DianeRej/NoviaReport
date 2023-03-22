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
        //Dal Profile
        public int CreateProfile(string firstName, string lastName)
        {
            Profile profil = new Profile() { Firstname = firstName, Lastname = lastName };
            _bddContext.Profiles.Add(profil);
            _bddContext.SaveChanges();
            return profil.Id;
        }
        //Dal Profile
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
        //Dal Profile
        public void UpdateProfile(Profile profile)
        {
            this._bddContext.Profiles.Update(profile);
            this._bddContext.SaveChanges();

        }
        //Dal User
        public int CreateUser(string login, string password)
        {
            User user = new User() { Login = login, Password = password };
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }
        //Dal Profile
        public int CreateUser(User user)
        {
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }
        //Dal Contact
        public int CreateContact(string personalMail, int personalPhone, string proMail,
            int proPhone, Adress adress, int adressId)
        {
            Contact contact = new Contact() { PersonalMail = personalMail , PersonalPhone = personalPhone, ProMail = proMail, ProPhone = proPhone, 
            Adress = adress, AdressId = adressId};
            _bddContext.Contacts.Add(contact);
            _bddContext.SaveChanges();
            return contact.Id;
        }
        //Dal Adress
        public int CreateAdress(string num, string street, int postalCode, string city)
        {
            Adress adress = new Adress() { Num = num, Street = street, PostalCode = postalCode, City = city};
            _bddContext.Adresses.Add(adress);
            _bddContext.SaveChanges();
            return adress.Id;
        }
        //Dal User
        public User Authentifier(string login, string password)
        {
            string motDePasse = EncodeMD5(password);
            User user = this._bddContext.Users.FirstOrDefault(u => u.Login == login && u.Password == motDePasse);
            return user;
        }
        //Dal User
        public User GetUser(int id)
        {
            return this._bddContext.Users.Find(id);
        }
        //Dal User
        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUser(id);
            }
            return null;
        }
        //Dal User
        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        void DeleteProfile(int id)
        {
            Profile profileToDelete = _bddContext.Profiles.Find(id);
            _bddContext.Profiles.Remove(profileToDelete);
            _bddContext.SaveChanges();
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
        //Dal Profile
        public List<Profile> GetAllProfiles()
        {
            return _bddContext.Profiles.ToList();
        }
    }
}
