using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;

namespace NoviaReport.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        public IActionResult DashboardAdmin()
        {
            DalUser dal = new DalUser();
            ViewData["UserList"] = dal.GetAllUsers();
            return View();
        }


        //je veux que le dashboard récupère l'id du user pour afficher la liste des salariés correspondant spécifiquement à ce manager
        //il faudrait aussi créer une vue qui affiche une liste des salariés d'un manager
        [Authorize(Roles = "MANAGER")]
        public IActionResult DashboardManager()
        {
            User user = new User();
            using (DalUser dal = new DalUser())
            {
                user = dal.GetUser(User.Identity.Name);
            }
            return View();
        }
    }
}
