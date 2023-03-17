
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Firstname { get; set; }
        [MaxLength(20)]
        public string Lastname { get; set; }
    }
}
