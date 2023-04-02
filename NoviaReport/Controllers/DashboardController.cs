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
                List<User> employeeList = new List<User> {};
                employeeList = dal.GetEmployeesOfAManager(id);
                int employeeNb = employeeList.Count;
                ViewData["EmployeesList"] = employeeList;
                ViewBag.EmployeeNb = employeeNb;

                int CRAInWaiting = 0;
                foreach (User employee in employeeList)
                {
                    List<UserCRA> cRAs = dal.GetCRAForOneUser(employee.Id);
                    foreach (UserCRA userCRA in cRAs)
                    {
                        if (userCRA.CRA.State.Equals(State.EN_COURS_DE_VALIDATION))
                        {
                            CRAInWaiting++;
                        }
                    }
                }
                ViewBag.CRAInWaiting = CRAInWaiting;
            }
            //faire un compteur des cra non validé pour chaque employé et additionner tous les compteurs
            

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
                int ToValidateCRAsNb = 0;
                foreach (UserCRA UserCRA in CRAs)
                {
                    if (UserCRA.CRA.State.Equals(State.EN_COURS_DE_VALIDATION))
                    {
                        ToValidateCRAsNb++;
                    }
                }
                ViewBag.ToValidateCRAsNb = ToValidateCRAsNb;

                int ToCompleteCRAsNb = 0;
                foreach (UserCRA UserCRA in CRAs)
                {
                    if (UserCRA.CRA.State.Equals(State.NON_VALIDE) || UserCRA.CRA.State.Equals(State.INCOMPLET))
                    {
                        ToCompleteCRAsNb++;
                    }
                }
                ViewBag.ToCompleteCRAsNb = ToCompleteCRAsNb;
            }
            using (DalRole dalRole = new DalRole())
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }

            return View();
        }
    }
}
