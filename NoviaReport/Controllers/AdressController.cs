using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using System.Linq;

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

        public IActionResult UpdateAdress()
        {
            using (DalAdress dal = new DalAdress())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult UpdateAdress(int id)
        {
            if (id != 0)
            {
                using (DalAdress dal = new DalAdress())
                {
                    Adress adress = dal.GetAllAdresses().Where(r => r.Id == id).FirstOrDefault();
                    if (adress == null)
                    {
                        return View("Error");
                    }
                    return View(adress);
                }
            }
            return View("Error");
        }

    }
}
