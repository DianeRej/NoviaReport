using System;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class ProfessionalInfo
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Statut")]
        public Position Position { get; set; } //enum
        [Required]
        [Display(Name = "Poste")]
        public Function Function { get; set; } //enum
        [Display(Name = "Date d'Arrivée")]
        public DateTime DateOfArrival { get; set; }
    }
    public enum Position
    {
        CADRE, DIRECTEUR, NONCADRE
    }

    public enum Function
    {
        INGENIEUR, DEVELOPPEUR, COMMERCIAL, RH, TECHNICIEN, RESPONSABLE_RESEAU, RESPONSABLE_SECURITE, CHEF_DE_PROJET, DIRECTEUR_COMMERCIAL, DIRECTEUR_GENERAL, PDG
    }
}
