using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoviaReport.Models.DAL_IDAL.Interfaces;

namespace NoviaReport.Models.DAL_IDAL
{

    public class DalProInfo : IDalProInfo
    {
        private BddContext _bddContext;

        //permet d'instancier le bddcontext (donc le lien vers la bdd)
        //on utilise cette méthode dans le controller à chaque fois que l'on veut appeler une méthode la dal
        public DalProInfo()
        {
            _bddContext = new BddContext();
        }

        //ajoute une ligne dans la table ProfessionalInfo 
        public int CreateProfessionalInfo(Position position, Function function, DateTime dateofarrival)
        {
            //on instancie un professionalInfo avec ses attributs
            ProfessionalInfo professionalInfo = new ProfessionalInfo() { Position = position, Function = function, DateOfArrival = dateofarrival };
            //on l'ajoute dans la bdd
            _bddContext.ProfessionalInfos.Add(professionalInfo);
            //on sauvegarde les modifications effectuées (obligatoire à chaque modification d'une table que ce soit création,
            //modif ou suppression d'une ligne)
            _bddContext.SaveChanges();
            return professionalInfo.Id;
        }

        //même principe mais cette fois les infos à modifier sont passées en arguments de la méthode
        public void UpdateProfessionalInfo(int id, Position position, Function function, DateTime dateOfArrival)
        {
            //on vérifie que l'id que l'on a indiqué existe bien dans la bdd
            ProfessionalInfo professionalInfo = _bddContext.ProfessionalInfos.Find(id);
            if (professionalInfo != null)
            {
                professionalInfo.Position = position;
                professionalInfo.Function = function;
                professionalInfo.DateOfArrival = dateOfArrival;
                _bddContext.SaveChanges();
            }
        }

        //permet de rechecher un id et de supprimer cette ligne (à actualiser quand j'implémenterai les méthodes de sup dans le controller)
        public void DeleteProfessionalInfo(int id)
        {
            ProfessionalInfo professionalInfo = _bddContext.ProfessionalInfos.Find(id);
            _bddContext.ProfessionalInfos.Remove(professionalInfo);
            _bddContext.SaveChanges();
        }

        //génère la liste de toutes les infosPro 
        public List<ProfessionalInfo> GetAllProfessionalInfo()
        {
            return _bddContext.ProfessionalInfos.ToList();
        }

        //méthode initiale qui ne devrait pas être dans toutes les Dal...
        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        //permet de "libérer" le bddcontext qu'on a instancié au début (voir première méthode)
        //obligatoire que cette méthode soit dans toutes les dal
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
