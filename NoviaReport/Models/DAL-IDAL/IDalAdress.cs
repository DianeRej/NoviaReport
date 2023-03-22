using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalAdress : IDisposable 
    
    {
        void DeleteCreateDatabase();

        int CreateAdress(string Num, string Street, int PostalCode, string City);

        void UpdateAdress(int id, string Num, string Street, int PostalCode, string City);
        void DeleteAdress(int id);

        List<Adress> GetAllAdresses();
       
    }
}
