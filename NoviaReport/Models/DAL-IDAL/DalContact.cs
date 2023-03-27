using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalContact : IDalContact
    {
        private BddContext _bddContext;
        //Méthode d'initialisation de la DB
        public DalContact()
        {
            _bddContext = new BddContext();
        }
        //Méthode pour créer un contact
        public int CreateContact(string personalMail, int personalPhone, string proMail, int proPhone)
        {
            Contact contact = new Contact() { PersonalMail = personalMail, PersonalPhone = personalPhone, ProMail= proMail, ProPhone= proPhone };
            _bddContext.Contacts.Add(contact);
            _bddContext.SaveChanges();
            return contact.Id;
        }

        public int CreateContact(string personalMail, int personalPhone, string proMail, int proPhone, Adress adress, int adressId)
        {
            Contact contact = new Contact() { PersonalMail = personalMail, PersonalPhone = personalPhone, ProMail = proMail, ProPhone = proPhone, Adress = adress, AdressId= adressId};
            _bddContext.Contacts.Add(contact);
            _bddContext.SaveChanges();
            return contact.Id;
        }
        //Méthode pour supprimer un contact
        public void DeleteContact(int id)
        {
            Contact contactToDelete = _bddContext.Contacts.Find(id);
            _bddContext.Contacts.Remove(contactToDelete);
            _bddContext.SaveChanges();

        }
        //Méthode pour modifier un contact
        public void UpdateContact(int id, string personalMail, int personalPhone, string proMail, int proPhone)
        {
            Contact contactToUpDate = _bddContext.Contacts.Find(id);
            if (contactToUpDate != null)
            {
                contactToUpDate.PersonalMail = personalMail;
                contactToUpDate.PersonalPhone = personalPhone;
                contactToUpDate.ProMail = proMail;
                contactToUpDate.ProPhone = proPhone;
                _bddContext.SaveChanges();
            }
        }
        //Méthode pour afficherla liste des contact
        public List<Contact> GetAllContact()
        {
            return _bddContext.Contacts.ToList();
        }
        //Méthode pour supprimer la base de données sur le serveur de base de données si elle existe ensuite la recréer
        
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }
        //Méthode pour libérer des ressources non managées
        public void Dispose()
        {
            _bddContext.Dispose();
        }

     

       
    }
}
