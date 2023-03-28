using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models
{
    public class CraActivity
    {
        public int Id { get; set; }
        public int CRAId { get; set; }
        public CRA CRA { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
