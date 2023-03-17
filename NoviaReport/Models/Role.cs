using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
