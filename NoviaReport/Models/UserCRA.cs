using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models
{
    //permet d'avoir plusieurs CRA pour un seul user (même principe que la classe role pour le user)
    public class UserCRA
    {
        public int Id { get; set; }
        //clé étrangère vers la table user
        public int UserId { get; set; }
        public User User { get; set; }
        //clé étrangère vers la table CRA
        public int CRAId { get; set; }
        public CRA CRA { get; set; }


    }
}