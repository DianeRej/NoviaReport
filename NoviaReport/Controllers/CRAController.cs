using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Controllers
{
    public class CRAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateActivity()
        {
            using (IDalActivity dal = new DalActivity())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateActivity(bool halfday, DateTime date)
        {
            DalTypeActivity dal = new DalTypeActivity();
            ViewData["ActivityTypes"] = dal.GetAllTypeActivities();
            return View("Add");
            /*
            if (!ModelState.IsValid)
                return View();

            using (DalActivity dal = new DalActivity())
            {
                dal.CreateActivity(halfday, date, otherActivities, absences, customersServices);
                return Redirect("/home/see...");
            }
            */
        }

        public IActionResult UpdateCRA(int id)
        {
            if (id != 0)
            {
                using (IDalCRA dal = new DalCRA())
                {
                    CRA craToUpDate = dal.GetAllCRAs().Where(c => c.Id == id).FirstOrDefault();
                    if (craToUpDate == null)
                    {
                        return View("Error");
                    }
                    return View(craToUpDate);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult UpdateCRA(CRA craToUpDate)
        {
            if (!ModelState.IsValid)
                return View(craToUpDate);

            if (craToUpDate.Id != 0)
            {
                using (DalCRA dal = new DalCRA())
                {
                    dal.UpdateCRA(craToUpDate);
                    return Redirect("/ home / see...");
                }
            }
            else
            {
                return View("Error");
            }
        }





















    }
}
