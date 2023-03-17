using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Users
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Login { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
        public int? ProfessionalInfoId { get; set; }
        public ProfessionalInfo ProfessionalInfo { get; set;}
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }  
    }
}
