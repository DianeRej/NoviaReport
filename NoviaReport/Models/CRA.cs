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
        public int? ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
    public enum State
    {
        EN_COURS_DE_VALIDATION, VALIDE, NON_VALIDE, INCOMPLET
    }
}
