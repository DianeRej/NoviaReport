using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoviaReport.Models.DAL_IDAL.Interfaces;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalActivity : IDalActivity
    {

        private BddContext _bddContext;

        //Méthode d'initialisation de la DB
        public DalActivity()
        {
            _bddContext = new BddContext();
        }

        //Méthodes pour créer une activité
        public int CreateActivity(bool halfday, DateTime date, TypeActivity typeActivity)
        {
            Activity activityToCreate = new Activity() { Halfday = halfday, Date = date, TypeActivity = typeActivity };
            _bddContext.Activities.Add(activityToCreate);
            _bddContext.SaveChanges();
            return activityToCreate.Id;
        }
        public int CreateActivity(Activity activity)
        {
            _bddContext.Activities.Add(activity);
            _bddContext.SaveChanges();
            return activity.Id;
        }


        //Méthode pour modifier une activité
        public void UpdateActivity(Activity activityToUpDate)
        {
            this._bddContext.Activities.Update(activityToUpDate);
            this._bddContext.SaveChanges();
        }

        //Méthode pour supprimer une activité

        public void DeleteActivity(int id)
        {
            Activity activityToDelete = _bddContext.Activities.Find(id);
            _bddContext.Activities.Remove(activityToDelete);
            _bddContext.SaveChanges();
        }


        //Méthode pour afficher la liste des activités
        public List<Activity> GetAllActivities()
        {
            return _bddContext.Activities.ToList();
        }


        //Méthode pour rechercher une activité grâce à son id
        public Activity GetActivityById(int id)

        {
            return this._bddContext.Activities.SingleOrDefault(u => u.Id == id);
        }


        //méthode pour créer une ligne de la table intermédiaire CRAActivity à partir d'un CRA et d'une Activity
        public int CreateCraActivity(CRA cra, Activity activity)
        {
            CraActivity CraActivity = new CraActivity() { CRAId = cra.Id, ActivityId = activity.Id };
            _bddContext.CraActivities.Add(CraActivity);
            _bddContext.SaveChanges();
            return CraActivity.Id;
        }

        //Génère la liste des CRAActivities pour la vue ListCraActivities
        public List<CraActivity> GetActivitiesCRA()
        {
            return _bddContext.CraActivities.Include(ca => ca.Activity).Include(ca => ca.CRA).ToList();
        }

        /*Methode pour afficher la liste des activités pour un CRA*/
        public List<CraActivity> GetActivitiesForOneCRA(int Id)

        {
            List<CraActivity> craActivities = _bddContext.CraActivities.Include(ca => ca.Activity).Include(ca => ca.CRA).Where(ca => ca.CRAId == Id).ToList();
            return craActivities;
        }

        //Méthode pour libérer des ressources non managées
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}

