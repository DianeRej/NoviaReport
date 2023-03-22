using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;

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
            using (Dal dal = new Dal())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return View();
            using (Dal dal = new Dal())

            {
                dal.CreateUser(user);

                return View();
            }
        }
    }
}
