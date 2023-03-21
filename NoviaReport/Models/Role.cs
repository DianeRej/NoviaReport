using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public Type Type { get; set; }
    }
    public enum Type
    {
        ADMIN, MANAGER, SALARIE
    }
}
