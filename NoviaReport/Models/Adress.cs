using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Adress
    {
        public int Id { get; set; }

        public string Num { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }

        public int PostalCode { get; set; }
        [MaxLength(30)]
        public string City { get; set; }

    }


}
