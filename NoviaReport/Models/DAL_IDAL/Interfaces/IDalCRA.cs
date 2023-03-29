using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL.Interfaces
{
    interface IDalCRA : IDisposable
    {
        int CreateCRA(DateTime Date, State State);

        void UpdateCRA(int id, DateTime Date, State State);

        List<CRA> GetAllCRAs();
    }
}
