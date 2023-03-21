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

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateContact(int id, string PersonalMail, int PersonalPhone, string ProMail, int ProPhone)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAllContact()
        {
            throw new NotImplementedException();
        }
        public void DeleteCreateDatabase()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

     

       
    }
}
