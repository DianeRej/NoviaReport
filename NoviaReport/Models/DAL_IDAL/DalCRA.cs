using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoviaReport.Models.DAL_IDAL.Interfaces;

namespace NoviaReport.Models.DAL_IDAL
{
    public class DalCRA : IDalCRA
    {
        private BddContext _bddContext;

        //Méthode d'initialisation de la DB
        public DalCRA()
        {
            _bddContext = new BddContext();
        }

        //Méthodes pour créer un CRA
        public int CreateCRA(DateTime date, State state)
        {
            CRA craToCreate = new CRA() { Date = date, State = state };
            _bddContext.CRAs.Add(craToCreate);
            _bddContext.SaveChanges();
            return craToCreate.Id;
        }
        public int CreateCRA(CRA cra)
        {
            cra.State = State.NON_VALIDE;
            _bddContext.CRAs.Add(cra);
            _bddContext.SaveChanges();
            return cra.Id;
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

        //méthode spécifique au salarié 
        //permet d'envoyer un CRA à un manager pour validation
        public void SubmitCra(CRA cra)
        {
            cra.State = State.EN_COURS_DE_VALIDATION;
            _bddContext.CRAs.Update(cra);
            _bddContext.SaveChanges();
        }

        //méthodes spécifique au manager 
        //permet d'évaluer l'état d'un CRA : le renvoyer pour correction
        //en modifiant son statut en INCOMPLET ou le valider en modifiant son statut en VALIDE
        public void ValidateCRA(CRA cra)
        {
            cra.State = State.VALIDE;
            _bddContext.CRAs.Update(cra);
            _bddContext.SaveChanges();
        }

        public void InvalidateCRA(CRA cra)
        {
            cra.State = State.INCOMPLET;
            _bddContext.CRAs.Update(cra);
            _bddContext.SaveChanges();
        }

        //Méthode pour supprimer un CRA : a priori on ne supprimera pas de CRA donc inutile
        //public void DeleteCRA(int id)
        //{
        //    CRA craToDelete = _bddContext.CRAs.Find(id);
        //    _bddContext.CRAs.Remove(craToDelete);
        //    _bddContext.SaveChanges();
        //}


        //Méthode pour afficherla liste de CRAs
        public List<CRA> GetAllCRAs()
        {
            return _bddContext.CRAs.ToList(); ;
        }

        //Méthode pour rechercher un CRA grâce à son id
        public CRA GetCRAById(int id)
        {
            return this._bddContext.CRAs.SingleOrDefault(u => u.Id == id);
        }

        //méthode pour créer une ligne dans la table intermédiaire UserCRA à partir d'un CRA et d'un user
        public int CreateUserCRA(CRA cra, User user)
        {
            UserCRA userCRA = new UserCRA() { CRAId = cra.Id, UserId = user.Id };
            _bddContext.UserCRAs.Add(userCRA);
            _bddContext.SaveChanges();
            return userCRA.Id;
        }

        //Méthode pour libérer des ressources non managées
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
