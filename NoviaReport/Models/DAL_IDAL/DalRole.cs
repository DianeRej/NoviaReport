using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoviaReport.Models.DAL_IDAL.Interfaces;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalRole : IDalRole
    {
        
        private BddContext _bddContext;

        //permet d'instancier le bddcontext (donc le lien vers la bdd)
        //on utilise cette méthode dans le controller à chaque fois que l'on veut appeler une méthode la dal
        public DalRole()
        {
            _bddContext = new BddContext();
        }

        //ajoute une ligne dans la table Role
        public int CreateRole(TypeRole typeRole, int userId)
        {
            //on instancie un professionalInfo avec ses attributs (son type et une réf (clé étrangère vers la table User))
            Role role = new Role() { TypeRole = typeRole, UserId = userId };
            //on l'ajoute dans la bdd
            _bddContext.Roles.Add(role);
            //on sauvegarde les modifications effectuées (obligatoire à chaque modification d'une table que ce soit création,
            //modif ou suppression d'une ligne)
            _bddContext.SaveChanges();
            return role.Id;
        }

        //même principe sauf que cette fois un role est directement passé
        //en argument de la méthode, c'est cette méthode qui est appelée pour la création du User
        public int CreateRole(Role role)
        {
            _bddContext.Roles.Add(role);
            _bddContext.SaveChanges();
            return role.Id;
        }

        //même principe que la création sauf que cette fois on passe un id en argument
        //
        public void UpdateRole(int id, Role role)
        {
            Role roleToUpdate = _bddContext.Roles.Find(id);
            roleToUpdate.TypeRole = role.TypeRole;
            _bddContext.Roles.Update(roleToUpdate);
            _bddContext.SaveChanges();
        }

        //public void DeleteRole(int id)
        //{
        //    Role roleToDelete = _bddContext.Roles.Find(id);
        //    _bddContext.Roles.Remove(roleToDelete);
        //    _bddContext.SaveChanges();
        //}

        //on obtient la liste des rôles d'un utilisateur
        public List<Role> GetRolesByUserId(int userId)
        {
            return _bddContext.Roles.Where(r => r.UserId == userId).ToList(); ;
        }

        //on obtient la liste de tous les rôles de tous les utilisateurs
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
