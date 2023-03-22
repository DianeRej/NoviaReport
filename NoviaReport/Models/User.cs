using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        //réf à la table contact
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }

        //réf à la table proinfo
        public int? ProfessionalInfoId { get; set; }
        public ProfessionalInfo ProfessionalInfo { get; set;}
        [Required]

        //réf à la table profile
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        //réf à la table role
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        // réf à son manager (boucle sur la table User (et est nul si le user n'a pas de manager : cas de l'admin)
        public int? ManagerId { get; set; }
        public User Manager { get; set; }

    }
}
