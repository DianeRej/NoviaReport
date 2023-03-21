
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        [MaxLength(20)]
        public string Lastname { get; set; }
    }
}
