using System;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Display(Name = "Rôle de l'utilisateur")]
        public Type  Type { get; set; } // enum

        //réf à la table user : dans la table role on a un id, un type et un userId
        //cela permet de pouvoir attribué un ou plusieurs rôle à un seul user
        public int? UserId { get; set; }
        public User User { get; set; }
    }

    public enum Type
    {
        ADMIN, MANAGER, SALARIE
    }
}
