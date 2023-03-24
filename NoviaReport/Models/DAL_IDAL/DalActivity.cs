using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalActivity : IDalActivity
    {
        private BddContext _bddContext;

        public DalActivity()
        {
            _bddContext = new BddContext();
        }

        public int CreateActivity(bool halfday, DateTime date, OtherActivities otherActivities, Absences absences, CustomersServices customersServices)
        {
            Activity activityToCreate = new Activity() { Halfday = halfday, Date = date, OtherActivities= otherActivities, Absences= absences, CustomersServices  = customersServices };
            _bddContext.Activities.Add(activityToCreate);
            _bddContext.SaveChanges();
            return activityToCreate.Id;
        }
        public void UpdateActivity(int id, bool halfday, DateTime date, OtherActivities otherActivities, Absences absences, CustomersServices customersServices)
        {
            Activity activityToUpDate = _bddContext.Activities.Find(id);
            if (activityToUpDate != null)
            {
                activityToUpDate.Halfday = halfday;
                activityToUpDate.Date = date;
                activityToUpDate.OtherActivities = otherActivities;
                activityToUpDate.Absences = absences;
                activityToUpDate.CustomersServices = customersServices;
                _bddContext.SaveChanges();
            }
        }
        public void DeleteActivity(int id)
        {
            Activity activityToDelete = _bddContext.Activities.Find(id);
            _bddContext.Activities.Remove(activityToDelete);
            _bddContext.SaveChanges();
        }

       

        public List<Activity> GetAllActivities()
        {
            return _bddContext.Activities.ToList();
        }
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
       
    }
}
