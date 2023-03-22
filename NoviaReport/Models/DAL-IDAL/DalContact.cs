using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalContact : IDalContact
    {
        private BddContext _bddContext;
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

        public void DeleteContact(int id)
        {
            Contact contactToDelete = _bddContext.Contacts.Find(id);
            _bddContext.Contacts.Remove(contactToDelete);
            _bddContext.SaveChanges();

        }
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
        public List<Contact> GetAllContact()
        {
            return _bddContext.Contacts.ToList();
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
