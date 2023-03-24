using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalUser : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateUser(string Login, string Password);

        public int CreateUser(User user);

        void UpdateUser(int id, string Login, string Password);

        List<User> GetAllUsers();

        void DeleteUser(int id);

    }
}
