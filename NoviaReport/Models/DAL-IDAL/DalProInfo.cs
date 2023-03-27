using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    
    public class DalProInfo : IDalProInfo
    {
        private BddContext _bddContext;
        //Méthode d'initialisation de la DB
        public DalProInfo()
        {
            _bddContext = new BddContext();
        }
        //Méthode pour créer les informations professionnelle
        public int CreateProfessionalInfo(Position position, Function function)
        {
            ProfessionalInfo professionalInfo = new ProfessionalInfo() { Position = position, Function = function };
            _bddContext.ProfessionalInfos.Add(professionalInfo);
            _bddContext.SaveChanges();
            return professionalInfo.Id;
        }
        //Méthode pour modifier les informations professionnelles
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
        //Méthode pour supprimer les informations professionnelles
        public void DeleteProfessionalInfo(int id)
        {

            ProfessionalInfo professionalInfo = _bddContext.ProfessionalInfos.Find(id);
            _bddContext.ProfessionalInfos.Remove(professionalInfo);
            _bddContext.SaveChanges();

        }
        //Méthode pour afficherla liste des informations professionnelles
        public List<ProfessionalInfo> GetAllProfessionalInfo()
        {
            return _bddContext.ProfessionalInfos.ToList();
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
