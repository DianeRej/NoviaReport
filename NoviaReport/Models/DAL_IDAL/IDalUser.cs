using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalUser : IDisposable
    {
        void DeleteCreateDatabase();


        public int CreateUser(User user);



        List<User> GetAllUsers();

        void DeleteUser(int id);

    }
}
