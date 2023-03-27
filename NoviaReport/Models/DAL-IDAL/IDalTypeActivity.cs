using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalTypeActivity : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateTypeActivity(Nom nom);

        void UpdateTypeActivity(int id, Nom nom);
        void DeleteTypeActivity(int id, Nom nom);

        List<TypeActivity> GetAllTypeActivities();
    }
}
