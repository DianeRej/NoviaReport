using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalActivity : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateActivity(bool Halfday, DateTime Date, TypeActivity typeActivity);

        void UpdateActivity(int id, bool Halfday, DateTime Date, TypeActivity typeActivity);
        void DeleteActivity(int id);

        List<Activity> GetAllActivities();
    }
}
