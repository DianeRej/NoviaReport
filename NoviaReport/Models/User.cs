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
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
        public int? ProfessionalInfoId { get; set; }
        public ProfessionalInfo ProfessionalInfo { get; set;}
        [Required]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
