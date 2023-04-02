using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models
{
    //permet d'avoir plusieurs activités dans un seul CRA
    public class CraActivity
    {
        public int Id { get; set; }
        //clé étrangère vers la table CRA
        public int CRAId { get; set; }
        public CRA CRA { get; set; }
        //clé étrangère vers la table Activity
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } 
    }
}