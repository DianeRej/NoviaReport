using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalRole : IDalRole
    {
        private BddContext _bddContext;
        public int CreateRole(Type type)
        {
            Role roleToCreate = new Role() { Type = type};
            _bddContext.Roles.Add(roleToCreate);
            _bddContext.SaveChanges();
            return roleToCreate.Id;
        }

        public void UpdateRole(int id, Type type)
        {
            Role roleToUpDate = _bddContext.Roles.Find(id);
            if (roleToUpDate != null)
            {
                roleToUpDate.Type = type;
                _bddContext.SaveChanges();
            }
        }

        public void DeleteRole(int id)
        {
            Role roleToDelete = _bddContext.Roles.Find(id);
            _bddContext.Roles.Remove(roleToDelete);
            _bddContext.SaveChanges();
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
