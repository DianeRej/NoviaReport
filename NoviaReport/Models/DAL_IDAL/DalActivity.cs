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

        //public int CreateActivity(bool halfday, DateTime date, OtherActivities otherActivities, Absences absences, CustomersServices customersServices)


        //Méthode pour créer une activité
        public int CreateActivity(bool halfday, DateTime date, TypeActivity typeActivity)
        {
            Activity activityToCreate = new Activity() { Halfday = halfday, Date = date, TypeActivity = typeActivity };
            _bddContext.Activities.Add(activityToCreate);
            _bddContext.SaveChanges();
            return activityToCreate.Id;
        }
        //Méthode pour modifier une activité
        public void UpdateActivity(int id, bool halfday, DateTime date, TypeActivity typeActivity)
        {
            Activity activityToUpDate = _bddContext.Activities.Find(id);
            if (activityToUpDate != null)
            {
                activityToUpDate.Halfday = halfday;
                activityToUpDate.Date = date;
                activityToUpDate.TypeActivity = typeActivity;

                _bddContext.SaveChanges();
            }
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
        public List<CraActivity> GetAllCraActivities()
        {
            return _bddContext.CraActivities
                .Include(ca => ca.Activity)
                .Include(ca => ca.CRA)
                .ToList();
                
                
        }

        public List<User> GetCRA()
        {
            var query = from role in _bddContext.Roles
                        join user in _bddContext.Users on role.UserId equals user.Id
                        where role.TypeRole.Equals(TypeRole.MANAGER) //correspond à un utilisateur Manager
                        select user;
            List<User> managers = query.ToList();

            return managers;
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

        public void UpdateActivity(Activity activityToUpDate)
        {
            this._bddContext.Activities.Update(activityToUpDate);
            this._bddContext.SaveChanges();
        }
    }
}
