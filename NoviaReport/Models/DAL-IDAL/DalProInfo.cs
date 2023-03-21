using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    
    public class DalProInfo : IDalProInfo
    {
        private BddContext _bddContext;
      public  int CreateProfessionalInfo(Position position, Function function)
        {
            ProfessionalInfo professionalInfo = new ProfessionalInfo() { Position = position, Function = function };
            _bddContext.ProfessionalInfos.Add(professionalInfo);
            _bddContext.SaveChanges();
            return professionalInfo.Id;
        }

       public void UpdateProfessionalInfo(int id, Position position, Function function)
        {
            ProfessionalInfo professionalInfo = _bddContext.ProfessionalInfos.Find(id);
            if (professionalInfo != null)
            {
                professionalInfo.Position = position;
                professionalInfo.Function = function;
                _bddContext.SaveChanges();
            }
        }

        public void DeleteProfessionalInfo(int id)
        {

            ProfessionalInfo professionalInfo = _bddContext.ProfessionalInfos.Find(id);
            _bddContext.ProfessionalInfos.Remove(professionalInfo);
            _bddContext.SaveChanges();

        }

       public List<ProfessionalInfo> GetAllProfessionalInfo()
        {
            return _bddContext.ProfessionalInfos.ToList();
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
