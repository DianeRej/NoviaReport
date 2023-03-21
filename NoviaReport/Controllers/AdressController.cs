using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;

namespace NoviaReport.Controllers
{
    public class AdressController : Controller
    {
        // GET: AdressController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAdress()
        {
            using (Dal dal = new Dal())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateAdress(string num, string street, int postalCode, string city)
        {
            if (!ModelState.IsValid)
                return View();
            using (Dal dal = new Dal())
            {
                dal.CreateAdress(num, street, postalCode, city);

                return View();
            }
        }
    }
}
