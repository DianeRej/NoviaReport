using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models.DAL_IDAL;

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
            using (DalAdress dal = new DalAdress())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateAdress(string num, string street, int postalCode, string city)
        {
            if (!ModelState.IsValid)
                return View();
            using (DalAdress dal = new DalAdress())
            {
                dal.CreateAdress(num, street, postalCode, city);

                return View();
            }
        }
    }
}
