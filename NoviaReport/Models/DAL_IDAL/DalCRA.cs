using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalCRA : IDalCRA
    {
        private BddContext _bddContext;

        public DalCRA()
        {
            _bddContext = new BddContext();
        }

        public int CreateCRA(DateTime date, State state)
        {
            CRA craToCreate = new CRA() { Date = date, State = state };
            _bddContext.CRAs.Add(craToCreate);
            _bddContext.SaveChanges();
            return craToCreate.Id;
        }
        public void UpdateCRA(int id, DateTime date, State state)
        {
            CRA craToUpDate = _bddContext.CRAs.Find(id);
            if (craToUpDate != null)
            {
                craToUpDate.Date = date;
                craToUpDate.State = state;
               
                _bddContext.SaveChanges();
            }
        }

        public void DeleteCRA(int id)
        {
            CRA craToDelete = _bddContext.CRAs.Find(id);
            _bddContext.CRAs.Remove(craToDelete);
            _bddContext.SaveChanges();
        }
        public List<CRA> GetAllCRAs()
        {
            return _bddContext.CRAs.ToList(); ;
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
