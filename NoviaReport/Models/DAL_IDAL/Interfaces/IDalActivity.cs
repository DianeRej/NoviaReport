using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL.Interfaces
{
    interface IDalActivity : IDisposable
    {
        int CreateActivity(bool Halfday, DateTime Date, TypeActivity typeActivity);

        void UpdateActivity(Activity activity);
        void DeleteActivity(int id);

        List<Activity> GetAllActivities();
        List<CraActivity> GetActivitiesCRA();
        List<CraActivity> GetActivitiesForOneCRA(int Id);
    }
}
