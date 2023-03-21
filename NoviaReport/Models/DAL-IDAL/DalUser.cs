using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalUser : IDalUser
    {
        private BddContext _bddContext;
      

        public int CreateUser(string login, string password)
        {
            User user = new User() { Login = login , Password = password };
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
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

        public List<User> GetAllUser()
        {
            return _bddContext.Users.ToList();
        }

        public void DeleteUser(int id)
        {
            User userToDelete = _bddContext.Users.Find(id);
            _bddContext.Users.Remove(userToDelete);
            _bddContext.SaveChanges();

        }

        public void UpdateUser(int id, string login, string password)
        {
            User user = _bddContext.Users.Find(id);
            if (user != null)
            {
                user.Login = login;
                user.Password = password;
                object p = _bddContext.SaveChanges();
            }
        }
    }
}
