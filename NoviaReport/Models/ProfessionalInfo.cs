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
        public DateTime DateOfArrival { get; set; }
    }
    public enum Position
    {
        CADRE, DIRECTEUR, NONCADRE
    }

    public enum Function
    {
        [Display(Name ="Ingénieur")]
        INGENIEUR,
        [Display(Name = "Développeur")]
        DEVELOPPEUR,
        [Display(Name = "Commercial")]
        COMMERCIAL,
        [Display(Name = "Ressource Humaines")]
        RH,
        [Display(Name = "Technicien")]
        TECHNICIEN,
        [Display(Name = "Responsable réseau")]
        RESPONSABLE_RESEAU,
        [Display(Name = "Responsable sécurité")]
        RESPONSABLE_SECURITE,
        [Display(Name = "Chef de projet")]
        CHEF_DE_PROJET,
        [Display(Name = "Directeur commercial")]
        DIRECTEUR_COMMERCIAL,
        [Display(Name = "Directeur général")]
        DIRECTEUR_GENERAL,
        [Display(Name = "Président directeur général")]
        PDG
    }
}
