using System;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public Type  Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum Type
    {
        ADMIN, MANAGER, SALARIE
    }
}
