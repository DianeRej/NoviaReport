using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NoviaReport.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //méthode get qui permet d'afficher le formulaire
        public IActionResult CreateUser()
        {
            using (DalUser dal = new DalUser())
            {
                //permet de générer la liste des personnes référencées comme manager pour être
                //proposées comme manager pour un nouvel utilisateur
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                return View();
            }
        }
        //post : est activée quand l'utilisateur clique sur le bouton submit du formulaire,
        //fait appel à la méthode de création de User (dans DalUser) et de Role (dans DalRole) tout en vérifiant toutes les
        //conditions des champs
        [HttpPost]
        public IActionResult CreateUser(User user, List<Type> Roles)
        {

            if (!ModelState.IsValid)
                return View();
            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                dal.CreateUser(user);
            }
            using (DalRole dalRole = new DalRole())
            {
                //on fait une boucle car il peut y avoir plusieurs role pour un seul utilisateur
                foreach (Type type in Roles)
                {
                    Role role = new Role() { Type = type, UserId = user.Id };
                    dalRole.CreateRole(role);
                }
            }
            return View();
        }

        //get : envoie sur un formulaire de modification identique à celui de création mais où les champs seront
        //déjà préremplis avec les informations initiales
        public IActionResult UpdateUser(int id)
        {
            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                User userToUpdate = dal.GetUserById(id);
                using (DalRole dalRole = new DalRole())
                {
                ViewData["RoleList"] = dalRole.GetRolesByUserId(id);
                }
                return View(userToUpdate);
            }
        }
        [HttpPost]
        public IActionResult UpdateUser(int id, User user, List<Type> Roles)
        {
            if (!ModelState.IsValid)
                return View();

            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                dal.UpdateUser(id, user);
            }
            using (DalRole dalRole = new DalRole())
            {
                foreach (Type type in Roles)
                {
                    Role role = new Role() { Type = type, UserId = user.Id };
                    dalRole.UpdateRole(id, role);
                }
            }
            return View();
        }
    }
}
