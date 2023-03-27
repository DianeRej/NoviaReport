using System;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public Type  Type { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }

    public enum Type
    {
        [Display(Name = "Administrateur")]
        ADMIN,
        [Display(Name = "Manager")]
        MANAGER,
        [Display(Name = "Salarié")]
        SALARIE
    }
}
