using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Identifiant")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        [MaxLength(20)]
        public string Lastname { get; set; }

        //réf à la table contact
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }

        //réf à la table proinfo
        public int? ProfessionalInfoId { get; set; }
        public ProfessionalInfo ProfessionalInfo { get; set; }

        //réf à la table role : enlevé, à la place on a une clé étrangère de user
        //dans la table role qui permet d'attribuer plusieurs roles à un employé

        // réf à son manager (boucle sur la table User (et est nul si le user n'a pas de manager : cas de l'admin)
        [Display(Name = "Nom du Manager")]
        public int? ManagerId { get; set; }
        public User Manager { get; set; }

    }
}
