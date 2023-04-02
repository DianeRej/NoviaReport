using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using System.Collections.Generic;
using System.Linq;

namespace NoviaReport.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        public IActionResult DashboardAdmin()
        {
            User user = new User();
            using (DalUser dalUser = new DalUser())
            {
                user = dalUser.GetUser(User.Identity.Name);
                List<User> userList = new List<User> { user };
                userList = dalUser.GetAllUsers();
                int userNb = userList.Count;
                ViewData["UserList"] = userList;
                ViewBag.UserNb = userNb;
            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }
            return View();
        }


        [Authorize(Roles = "MANAGER")]
        public IActionResult DashboardManager(int id)
        {
            User user = new User();
            using (DalUser dal = new DalUser())
            {
                user = dal.GetUser(User.Identity.Name);
                ViewData["EmployeesList"] = dal.GetEmployeesOfAManager(id);
            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }

            return View();
        }

        [Authorize(Roles = "SALARIE")]
        public IActionResult DashboardSalarie(int id)
        {
            User user = new User();
            using (DalUser dal = new DalUser())
            {

                user = dal.GetUser(User.Identity.Name);
                ViewData["UserCRAsList"] = dal.GetCRAForOneUser(id);
            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }

            return View();
        }
    }
}
