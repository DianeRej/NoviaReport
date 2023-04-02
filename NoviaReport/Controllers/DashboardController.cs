using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.Models.DAL_IDAL.Interfaces;
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
                List<User> employeeList = new List<User> { user };
                employeeList = dal.GetEmployeesOfAManager(id);
                int employeeNb = employeeList.Count;
                ViewData["EmployeesList"] = employeeList;
                ViewBag.EmployeeNb = employeeNb;
            }

            //permet de vérifier quels roles à le user : s'il a plusieurs roles, il y aura un lien pour changer de vue dans le header du dashboard
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
                List<UserCRA> CRAs = new List<UserCRA>();
                CRAs = dal.GetCRAForOneUser(id);
                ViewData["UserCRAsList"] = CRAs;

                //List<UserCRA> ToValidateCRAs = (List<UserCRA>)CRAs.Where(cra => cra.CRA.State.Equals(State.EN_COURS_DE_VALIDATION));
                //int ToValidateCRAsNb = ToValidateCRAs.Count;
                //ViewBag.ToValidateCRAsNb = ToValidateCRAsNb;

                //List<UserCRA> ToCompleteCRAs = (List<UserCRA>)CRAs.Where(cra => cra.CRA.State.Equals(State.NON_VALIDE));
                //int ToCompleteCRAsNb = ToCompleteCRAs.Count;
                //ViewBag.ToCompleteCRAsNb = ToCompleteCRAsNb;
            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }

            return View();
        }
    }
}
