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
        //get : envoie sur le fomulaire de création d'une activité 
        //doit avoir une référence du CRA auquel elle appartient : ici c'est l'id du CRA qu'on passe en argument
        public IActionResult CreateActivity(int CRAid)
        {
            if (CRAid != 0)
            {
                using (DalActivity dal = new DalActivity())
                {
                    ViewBag.CRAid = CRAid;
                    return View();
                }
            } else 
            { 
                return View("Error"); 
            }
        }
        //Méthode post pour créer une activité
        [HttpPost]
        public IActionResult CreateActivity(Activity activity, int CRAid)
        {
            if (!ModelState.IsValid)// pour verifier si les infos saisis sont cohérentes
                return View();

            CRA cra = new CRA();
            using (DalCRA dal = new DalCRA())
            {
                cra = dal.GetAllCRAs().Where(r => r.Id == CRAid).FirstOrDefault();
            }
            using (DalActivity dal = new DalActivity())
            {
                dal.CreateActivity(activity);
                dal.CreateCraActivity(cra, activity);
                
            }
            return Redirect("/CRA/CreateActivity");
        }

        //Méthode get, pour modifier une activité qui renvoie vers un formulaire de modification prérempli
        //avec les informations existantes dans la DB (a travers l'id)
        public IActionResult UpdateActivity(int id)
        {
            if (id != 0)
            {
                Activity activityToUpdate = new Activity();
                using (DalActivity dal = new DalActivity())
                {
                    activityToUpdate = dal.GetActivityById(id);
                    
                }
                return View(activityToUpdate);
            }
            return View("Error");
        }
        //Méthode post pour modifier une activité
        [HttpPost]
        public IActionResult UpdateActivity(Activity ActivityToUpDate)
        {
            if (!ModelState.IsValid)
                return View(ActivityToUpDate);

            if (ActivityToUpDate.Id != 0)
            {
                using (DalActivity dal = new DalActivity())
                {
                    dal.UpdateActivity(ActivityToUpDate);
                    return Redirect("/CRA/UpDateActivity");
                }
            }
            else
            {
                return View("Error");
            }
        }


        //Méthode get pour la modification d'un CRA, qui renvoie vers un formulaire de modification préremplis
        //avec les informations existantes dans la DB (a travers l'id)
        public IActionResult UpdateCRA(int id)
        {
            if (id != 0)
            {
                using (DalCRA dal = new DalCRA())
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
                    return Redirect("/CRA/UpDateCRA");
                }
            }
            else
            {
                return View("Error");
            }
        }

        /* public IActionResult CreateCRA(DateTime date, State state)
         {
             if (!ModelState.IsValid)// pour verifier si les infos saisis sont cohérentes
                 return View();

             using (DalActivity dal = new DalActivity())
             {
                 dal.CreateCRA( date, state);
                 return Redirect("/CRA/CreateCRA");
             }

         }*/

    }
}
