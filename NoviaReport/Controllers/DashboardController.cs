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
            User user = new User();
            using (DalUser dalUser = new DalUser())
            {
                user = dalUser.GetUser(User.Identity.Name);
                ViewBag.name = user.Firstname;
            }
            DalUser dal = new DalUser();
            ViewData["UserList"] = dal.GetAllUsers();
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
                ViewBag.name = user.Firstname;
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
                //pour le message de bienvenu
                user = dal.GetUser(User.Identity.Name);

                ViewBag.name = user.Firstname;
                ViewData["UserCRAsList"] = dal.GetCRAForOneUser(id);
            }
            CRA _cra = null;
            using (DalCRA dal = new DalCRA())
            {
                _cra = dal.GetCurrentCRAByUser(id);
                if (_cra == null) {
                    ViewBag.cra_message = "Vous n\'avez pas encore debutez la saisie de CRA";
                }
                else
                {
                    string sta = "";
                    /*
                    switch (_cra.State)
                    {
                        case _cra.:
                            sta = "incomplet";
                            break;
                        case 1:
                            sta = "en cours de validation";
                            break;
                        case 2:
                            sta = "validé";
                            break;
                        case 3:
                            sta = "réfusé";
                            break;
                    }
                    */
                    ViewBag.cra_message = "Votre CRA du "+ _cra.Date.Month +"/"+ _cra.Date.Year + " est " + _cra.State;
                }
            }
                using (DalRole dalRole = new DalRole()) 
            {
                ViewData["UserRolesList"] = dalRole.GetRolesByUserId(user.Id);
            }
             
            return View();
        }
    }
}
