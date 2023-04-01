using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.ViewModels;
using System;
using System.Linq;

namespace NoviaReport.Controllers
{
    [Authorize]
    public class CRAController : Controller
    {


        //get : envoie sur le fomulaire de création d'une activité 
        //doit avoir une référence du CRA auquel elle appartient : ici c'est l'id du CRA qu'on passe en argument
        //Pour pouvoir ajouter une activité il y a 2 conditions : le CRAid doit correspondre à un CRA existant ET 
        //le statut du CRA doit être NON_VALIDE ou INCOMPLET
        [Authorize(Roles = "SALARIE")]
        public IActionResult CreateActivityForm(int CRAid)
        {
            CRA craToComplete = new CRA();
            using (DalCRA dal = new DalCRA())
            {
                craToComplete = dal.GetCRAById(CRAid);
            }
            if (CRAid == 0)
            {
                return View("Error");
            }
            if (craToComplete.State.Equals(State.NON_VALIDE) || craToComplete.State.Equals(State.INCOMPLET))
            {

                using (DalActivity dal = new DalActivity())
                {
                    ViewBag.CRAid = CRAid;
                }
                return View();
            }
            else
            {
                return View("Error");
            }
        }
        //Méthode post pour créer une activité
        [HttpPost]
        public IActionResult CreateActivityForm(Activity activity, int CRAid)
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
            return Redirect("/cra/getactivitiescra/"+cra.Id); //à changer pour un lien vers la liste des acitivités
        }


        //Méthode post pour créer une activité à partir du calendrier
        [HttpPost]
        public IActionResult CreateActivity([FromBody] ActivityFromFetch res)
        {
            if (!ModelState.IsValid)// pour verifier si les infos saisis sont cohérentes
                return View();

            using (DalCRA dal = new DalCRA())
            {
                CRA cra = dal.GetAllCRAs().Where(r => r.Id == Convert.ToInt32(res.craId)).FirstOrDefault();
                using (DalActivity ctx = new DalActivity())
                {
                    Activity activity = new Activity { Date = System.DateTime.Now, TypeActivity = (TypeActivity)Enum.Parse(typeof(TypeActivity), res.activityType), Client = (Client)Enum.Parse(typeof(Client), res.client) };
                    ctx.CreateActivity(activity);
                    ctx.CreateCraActivity(cra, activity);

                }
            }
           
            return Redirect("/home/index"); //à changer pour un lien vers la liste des acitivités
        }

        //Méthode get, pour modifier une activité qui renvoie vers un formulaire de modification prérempli
        //avec les informations existantes dans la DB (a travers l'id)
        [Authorize(Roles = "SALARIE")]
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
                    return Redirect("/home/index"); //à changer pour un lien vers la liste des activités
                }
            }
            else
            {
                return View("Error");
            }
        }

        //get : envoie sur le fomulaire de création d'un CRA
        //prend en argument un userId
        //C'est le salarié qui crée son CRA en entrant la date (01/mois/année) ; l'état initial du CRA est fixé à NON_VALIDE
        [Authorize(Roles = "SALARIE")]
        public IActionResult UpdateCRA(int craId)
        {
            if (craId != 0)
            {
                using (DalCRA dal = new DalCRA())
                {
                    CRA cra = dal.GetCRAById(craId);
                    int monthCRA = cra.Date.Month;
                    int yearCRA = cra.Date.Year;
                    ViewBag.craMonth = monthCRA-1;
                    ViewBag.craYear = yearCRA;
                    ViewBag.craId = craId;
                }
                return View();
            }
            else return View("Error");
        }

        //Méthode post pour créer un CRA
        [HttpPost]
        public IActionResult UpdateCRA(CRA cra, int userId)
        {
            if (!ModelState.IsValid)// pour verifier si les infos saisis sont cohérentes
                return View();
            User user = new User();
            using (DalUser dal = new DalUser())
            {
                user = dal.GetUserById(userId);
            }
            using (DalCRA dal = new DalCRA())
            {
                dal.CreateCRA(cra);
                dal.CreateUserCRA(cra, user);
                return Redirect("/home/index"); //à changer pour un lien vers la liste des cra ou le dashboard du User ?
            }

        }

        //Méthode get pour la modification d'un CRA, qui renvoie vers un formulaire de modification préremplis
        //avec les informations existantes dans la DB (a travers l'id)
        public IActionResult UpdateCRAold(int id)
        {
            if (id != 0)
            {
                using (DalCRA dal = new DalCRA())
                {
                    CRA craToUpDate = dal.GetCRAById(id);
                    return View(craToUpDate);
                }
            }
            return View("Error");
        }

 
        //Méthode post pour modifier le CRA

        [HttpPost]
        public IActionResult UpdateCRAold(CRA craToUpDate)
        {
            if (!ModelState.IsValid)
                return View(craToUpDate);

            if (craToUpDate.Id != 0)
            {
                using (DalCRA dal = new DalCRA())
                {
                    dal.UpdateCRA(craToUpDate);
                    return Redirect("/home/index"); //à changer pour un lien vers la liste des cra ou le dashboard salarié ?
                }
            }
            else
            {
                return View("Error");
            }
        }



        public IActionResult SeeActivity()
        {
            DalActivity dal = new DalActivity();
            ViewData["ActivityList"] = dal.GetAllActivities();
            return View("ActivityList");
        }

        [Authorize(Roles = "SALARIE")]
        public IActionResult SubmitCRA(int id)
        {
            User user = new User();
            using (DalUser dalUser = new DalUser())
            {
                user = dalUser.GetUser(User.Identity.Name);
            }
            using (DalCRA dal = new DalCRA())
            {
                CRA craToSubmit = dal.GetCRAById(id);
                dal.SubmitCra(craToSubmit);
            }
            return Redirect("/Dashboard/DashboardSalarie/" + user.Id); //à changer pour un lien vers la liste des CRA ou le dashboard salarié ?
        }

        //Méthode pour afficher la liste des Activites et des CRA
        [Authorize]
        public IActionResult ListActivitiesCRA()
        {
            DalActivity dal = new DalActivity();
            ViewData["ActivitiesCRAList"] = dal.GetActivitiesCRA();
            return View("ListActivitiesCRA");


        }

        //Méthode pour afficher les Activités liées à un CRA
        [Authorize]
        public IActionResult GetActivitiesCRA(int id)
        {
            CraActivitiesViewModel viewModel = new CraActivitiesViewModel { };

            using (DalCRA dalCRA = new DalCRA())
            {
                viewModel.Cra = dalCRA.GetCRAById(id);
            }

            using (DalActivity dal = new DalActivity())
            {
                viewModel.CraActivities = dal.GetActivitiesForOneCRA(id);
            }
            return View("GetActivitiesCRA", viewModel);


    }

}
}
