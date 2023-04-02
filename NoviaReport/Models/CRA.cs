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
        INCOMPLET, EN_COURS_DE_VALIDATION, VALIDE, NON_VALIDE
    }
}
