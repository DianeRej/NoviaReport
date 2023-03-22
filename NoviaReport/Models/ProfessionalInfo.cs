using System;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class ProfessionalInfo
    {
        public int Id { get; set; }
        [Required]
        public Position Position { get; set; } //cadre, non cadre... enum
        [Required]
        public Function Function { get; set; } //poste : ingénieur, développeur... enum
        [Required]
        public DateTime DateOfArrival { get; set; }
    }
    public enum Position
    {
        CADRE, DIRECTEUR, SALARIE
    }

    public enum Function
    {
        INGENIEUR, DEVELOPPEUR, COMMERCIAL, RH, TECHNICIEN, RESPONSABLE_RESEAU, RESPONSABLE_SECURITE, CHEF_DE_PROJET, DIRECTEUR_COMMERCIAL, DIRECTEUR_GENERAL, PDG
    }
}
