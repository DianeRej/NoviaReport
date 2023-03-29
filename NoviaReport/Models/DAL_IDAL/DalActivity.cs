﻿using System;
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

        //public int CreateActivity(bool halfday, DateTime date, OtherActivities otherActivities, Absences absences, CustomersServices customersServices)


        //Méthode pour créer une activité
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


        //Méthode pour afficherla liste des activités
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
            CraActivity CraActivity = new CraActivity() { CRAId = cra.Id, ActivityId=activity.Id};
            _bddContext.CraActivities.Add(CraActivity);
            _bddContext.SaveChanges();
            return CraActivity.Id;
        }


        //Méthode pour rechercher une CraActivity grâce à l'id de l'activity
        public CraActivity GetCraActivityByActivityId(int actId)
        {
            return this._bddContext.CraActivities.SingleOrDefault(u => u.ActivityId == actId);
        }

        //Méthode pour supprimer la base de données sur le serveur de base de données si elle existe ensuite la recréer
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }
        //Méthode pour libérer des ressources non managées
        public void Dispose()
        {
            _bddContext.Dispose();
        }

        
    }
}
