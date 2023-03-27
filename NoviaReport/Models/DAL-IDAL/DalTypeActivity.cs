using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalTypeActivity : IDalTypeActivity
    {
        private BddContext _bddContext;
        public int CreateTypeActivity(Nom nom)
        {
            TypeActivity TypeactivityToCreate = new TypeActivity() { nom = nom };
            _bddContext.TypeActivities.Add(TypeactivityToCreate);
            _bddContext.SaveChanges();
            return TypeactivityToCreate.Id;
        }

        public void UpdateTypeActivity(int id,Nom nom)
        {
            TypeActivity TypeActivityToUpDate = _bddContext.TypeActivities.Find(id);
            if (TypeActivityToUpDate != null)
            {
                TypeActivityToUpDate.nom = nom;

                _bddContext.SaveChanges();
            }
        }

        public void DeleteTypeActivity(int id,Nom nom)
        {
            TypeActivity TypeActivityToDelete = _bddContext.TypeActivities.Find(id);
            _bddContext.TypeActivities.Remove(TypeActivityToDelete);
            _bddContext.SaveChanges();
        }

        public List<TypeActivity> GetAllTypeActivities()
        {
            return _bddContext.TypeActivities.ToList();
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
