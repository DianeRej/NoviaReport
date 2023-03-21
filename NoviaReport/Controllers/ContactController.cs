using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;

namespace NoviaReport.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContact()
        {
            using (Dal dal = new Dal())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateContact(string personalMail, int personalPhone, string proMail, 
            int proPhone, Adress adress, int adressId)
        {
            if (!ModelState.IsValid)
                return View();
            using (Dal dal = new Dal())
            {
                dal.CreateContact(personalMail, personalPhone, proMail, proPhone, adress, adressId);

                return View();
            }
        }
    }
}
