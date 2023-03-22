using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalAdress : IDalAdress
    {
        private BddContext _bddContext;


        public int CreateAdress(string num, string street, int postalCode, string city)
        {
            Adress adress = new Adress() { Num = num, Street = street, PostalCode = postalCode, City = city };
            _bddContext.Adresses.Add(adress);
            _bddContext.SaveChanges();
            return adress.Id;
        }

            public void UpdateAdress(int id, string num, string street, int postalCode, string city)
        {
            Adress adressToUpDate = _bddContext.Adresses.Find(id);
            if (adressToUpDate != null)
            {
                adressToUpDate.Num = num;
                adressToUpDate.Street = street;
                adressToUpDate.PostalCode = postalCode;
                adressToUpDate.City = city;
               

                _bddContext.SaveChanges();
            }
        }
        public void DeleteAdress(int id)
        {
                Adress adressToDelete = _bddContext.Adresses.Find(id);
                _bddContext.Adresses.Remove(adressToDelete);
                _bddContext.SaveChanges();
        }
        public List<Adress> GetAllAdresses()
        {
            return _bddContext.Adresses.ToList(); ;
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
