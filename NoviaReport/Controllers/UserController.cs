using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;

namespace NoviaReport.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateUser()
        {
            using (DalUser dal = new DalUser())
            {
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
