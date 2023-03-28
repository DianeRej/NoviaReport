using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NoviaReport.Controllers
{
    
    //[Authorize]
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
        public IActionResult CreateUser(User user, List<TypeRole> TypeRoles)
        {

            if (!ModelState.IsValid) //permet de vérifier que les info rentrées sont cohérentes
                return View();

            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                dal.CreateUser(user);
            }
            using (DalRole dalRole = new DalRole())
            {
                //on fait une boucle car il peut y avoir plusieurs roles pour un seul utilisateur
                foreach (TypeRole typeRole in TypeRoles)
                {
                    Role role = new Role() { TypeRole = typeRole, UserId = user.Id };
                    dalRole.CreateRole(role);
                }
            }
            return View();
        }

        //get : envoie sur un formulaire de modification identique à celui de création mais où les champs seront
        //déjà préremplis avec les informations initiales
        public IActionResult UpdateUser(int id)
        {
            User userToUpdate = new User();
            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                userToUpdate = dal.GetUserById(id);
                //comme un utilisateur peut avoir un ou plusieurs rôles, on génère une liste de ces rôles en utilisant l'id du user

            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["RoleList"] = dalRole.GetRolesByUserId(id);
            }
            return View(userToUpdate);
        }

        //post : donc on envoie les informations modifiées dans la base de données et on retourne
        //sur la page d'accueil (redirection qui pourra être modifiée plus tard)
        [HttpPost]
        public IActionResult UpdateUser(int id, User user, List<TypeRole> TypeRoles)
        {
            //retrouve la liste des rôles associés à l'utilisateur (sert à cocher les bonnes checkbox)
            using (DalRole dalRole1 = new DalRole())
            {
                ViewData["RoleList"] = dalRole1.GetRolesByUserId(id);
            }

            if (!ModelState.IsValid) //vérifie ques les infos rentrées sont cohérentes avec le modèle
                return View();

            using (DalUser dal = new DalUser())
            {
                //génère la liste des managers (pour la liste déroulante) normalement il n'y en a plus besoin
                //List<User> managers = dal.GetManagers();
                //ViewData["ManagerList"] = managers;
                //met à jour les infos du user
                dal.UpdateUser(id, user);
            }

            using (DalRole dalRole = new DalRole())
            {
                foreach (TypeRole typeRole in TypeRoles)
                {
                    Role role = new Role() { TypeRole = typeRole, UserId = user.Id };
                    dalRole.UpdateRole(id, role);
                }
            }
            return Redirect("/home/Index");
        }
    }
}
