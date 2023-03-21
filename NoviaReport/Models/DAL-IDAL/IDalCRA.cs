using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalCRA : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateCRA(DateTime Date, State State);

        void UpdateCRA(int id, DateTime Date, State State);
        void DeleteCRA(int id);

        List<CRA> GetAllCRAs();
      
    }
}
