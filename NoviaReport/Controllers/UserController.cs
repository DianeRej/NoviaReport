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
                //List<User> managers = dal.GetManagers();
                //ViewData["ManagerList"] = managers;
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {

            if (!ModelState.IsValid)
                return View();
            using (DalUser dal = new DalUser())
            {

                dal.CreateUser(user);

                return View();
            }
        }
    }
}
