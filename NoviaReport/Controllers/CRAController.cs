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
        //Méthode post pour créer une activité
        [HttpPost]
        public IActionResult CreateActivity(bool halfday, DateTime date, TypeActivity typeActivity)
        {
            if (!ModelState.IsValid)// pour verifier si les infos saisis sont cohérentes
                return View();

            using (DalActivity dal = new DalActivity())
            {
                dal.CreateActivity(halfday, date, typeActivity);
                return Redirect("/CRA/CreateActivity");
            }
            
        }
        //Méthode get de modification de CRA qui renvoie vers un formulaire de modification préremplis
        //avec les informations existantes dans la DB (a travers l'id)
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
        //Méthode post pour modifier le CRA
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
                    return Redirect("/CRA/UpDateActivity");
                }
            }
            else
            {
                return View("Error");
            }
        }





















    }
}
