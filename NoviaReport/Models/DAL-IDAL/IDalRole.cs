using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalRole : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateRole(string Type);

        void UpdateRole(int id, string Type);
        void DeleteRole(int id);

        List<Role> GetAllRoles();
    }
}
