using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoviaReport.Models.DAL_IDAL.Interfaces;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalCRA : IDalCRA
    {
        private BddContext _bddContext;

        ////Méthode d'initialisation de la DB

        public DalCRA()
        {
            _bddContext = new BddContext();
        }

        //Méthode pour créer un CRA

        public int CreateCRA(DateTime date, State state)
        {
            CRA craToCreate = new CRA() { Date = date, State = state };
            _bddContext.CRAs.Add(craToCreate);
            _bddContext.SaveChanges();
            return craToCreate.Id;
        }
        //Méthodes pour modifier un CRA 
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
        public void UpdateCRA(CRA craToUpDate)
        {
            this._bddContext.CRAs.Update(craToUpDate);
            this._bddContext.SaveChanges();

        }
        //Méthode pour supprimer une activité
        public void DeleteCRA(int id)
        {
            CRA craToDelete = _bddContext.CRAs.Find(id);
            _bddContext.CRAs.Remove(craToDelete);
            _bddContext.SaveChanges();
        }
        //Méthode pour afficherla liste de CRAs
        public List<CRA> GetAllCRAs()
        {
            return _bddContext.CRAs.ToList(); ;
        }

        //Méthode pour supprimer la base de données sur le serveur de base de données si elle existe ensuite la recréer
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }
        //Méthode pour libérer des ressources non managées
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
