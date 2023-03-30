using NoviaReport.Models;
using System.Collections.Generic;

namespace NoviaReport.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public bool Authentifie { get; set; }
    }
}
