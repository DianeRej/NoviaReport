using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalRole : IDalRole
    {
        private BddContext _bddContext;

        public DalRole()
        {
            _bddContext = new BddContext();
        }

        public int CreateRole(Type type, int userId)
        {
            Role role = new Role() { Type = type, UserId = userId };
            _bddContext.Roles.Add(role);
            _bddContext.SaveChanges();
            return role.Id;
        }

        public int CreateRole(Role role)
        {
            _bddContext.Roles.Add(role);
            _bddContext.SaveChanges();
            return role.Id;
        }

        public void UpdateRole(int id, Role role)
        {
            Role roleToUpdate = _bddContext.Roles.Find(id);
            if (roleToUpdate != null)
            {
                _bddContext.Roles.Update(role);
                _bddContext.SaveChanges();
            }
        }

        //public void DeleteRole(int id)
        //{
        //    Role roleToDelete = _bddContext.Roles.Find(id);
        //    _bddContext.Roles.Remove(roleToDelete);
        //    _bddContext.SaveChanges();
        //}

        public List<Role> GetRolesByUserId(int userId)
        {
            return _bddContext.Roles.Where(r => r.UserId == userId).ToList(); ;
        }

        public List<Role> GetAllRoles()
        {
            return _bddContext.Roles.ToList(); ;
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
