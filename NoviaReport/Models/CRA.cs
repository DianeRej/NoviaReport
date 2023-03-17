using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace NoviaReport.Models
{
    public class CRA
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    
        public Activity Activity { get; set; }

        public string State { get; set; } // enum a faire: en cours...
    }
}
