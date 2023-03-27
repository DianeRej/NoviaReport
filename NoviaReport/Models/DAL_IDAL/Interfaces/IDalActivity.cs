using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL.Interfaces
{
    interface IDalActivity : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateActivity(bool Halfday, DateTime Date, OtherActivities OtherActivities, Absences Absences, CustomersServices CustomersServices);

        void UpdateActivity(int id, bool Halfday, DateTime Date, OtherActivities OtherActivities, Absences Absences, CustomersServices CustomersServices);
        void DeleteActivity(int id);

        List<Activity> GetAllActivities();
    }
}
