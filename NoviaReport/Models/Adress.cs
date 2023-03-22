using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }

    }


}
