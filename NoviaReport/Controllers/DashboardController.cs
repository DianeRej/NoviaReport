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


        [Authorize(Roles = "MANAGER")]
        public IActionResult DashboardManager(int id)
        {
            User user = new User();
            using (DalUser dal = new DalUser())
            {
                user = dal.GetUser(User.Identity.Name);
                ViewData["EmployeesList"] = dal.GetEmployeesOfAManager(id);
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
            }
            return View();
        }
    }
}
