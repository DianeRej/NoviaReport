using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using NoviaReport.Models;
using Microsoft.EntityFrameworkCore;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalUser : IDalUser
    {
        private BddContext _bddContext;

        public DalUser()
        {
            _bddContext = new BddContext();
        }


        public int CreateUser(string login, string password)
        {
            string motDePasse = EncodeMD5(password);
            User user = new User() { Login = login, Password = motDePasse };
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }
        public int CreateUser(User user)
        {
            if (user.ManagerId == 0)
            {
                user.ManagerId = null;
            }
            user.Password = EncodeMD5(user.Password);
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
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

        public User Authentifier(string login, string password)
        {
            string motDePasse = EncodeMD5(password);
            User user = this._bddContext.Users.FirstOrDefault(u => u.Login == login && u.Password == motDePasse);
            return user;
        }
        public User GetUser(int id)
        {
            return this._bddContext.Users.Find(id);
        }

        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUser(id);
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return _bddContext.Users
                .Include(u=>u.ProfessionalInfo)
                .Include(u=>u.Role)
                .ToList();
           
        }
       
        public List<User> GetManagers()
        {
            var query = from role in _bddContext.Roles
                        join user in _bddContext.Users on role.UserId equals user.Id
                        where role.Type.Equals(Type.MANAGER) //correspond à un utilisateur Manager
                        select user;
            List<User> managers = query.ToList();

            return managers;
        }
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
