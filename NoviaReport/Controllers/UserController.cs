using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using System.Collections.Generic;

namespace NoviaReport.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //GET : UserController
        public IActionResult CreateUser()
        {
            using (DalUser dal = new DalUser())
            {
                List<User> managers = dal.GetManagers();
                ViewData["ManagerList"] = managers;
                return View();
            }
        }
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
                foreach (Type type in Roles)
                {
                    Role role = new Role() { Type = type, UserId = user.Id };
                    dalRole.CreateRole(role);
                }
            }
            return View();

        }
    }
}
