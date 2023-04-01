using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace NoviaReport.Models
{
    public class CRA
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }

    }
    public enum State
    {
        [Display(Name= "En cours de validation" )]
        EN_COURS_DE_VALIDATION,
        [Display(Name = "Validé")]
        VALIDE,
        [Display(Name = "Non validé")]
        NON_VALIDE,
        [Display(Name = "Incomplet")]
        INCOMPLET
    }
}
