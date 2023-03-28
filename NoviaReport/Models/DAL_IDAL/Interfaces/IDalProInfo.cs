using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL.Interfaces
{
    interface IDalProInfo : IDisposable
    {
        public void DeleteCreateDatabase();

        public int CreateProfessionalInfo(Position Position, Function Function, DateTime dateofarrival);

        public void UpdateProfessionalInfo(int id, Position Position, Function Function, DateTime dateOfArrival);
        public void DeleteProfessionalInfo(int id);

        public List<ProfessionalInfo> GetAllProfessionalInfo();
    }
}
