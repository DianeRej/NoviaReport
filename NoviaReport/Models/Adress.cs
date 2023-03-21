using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Adress
    {
        public int Id { get; set; }
        [Display(Name = "Numéro de rue")]
        [MaxLength(8)]
        public string Num { get; set; }
        [Display(Name = "Rue")]
        [MaxLength(50)]
        public string Street { get; set; }
        [Display(Name = "Code Postal")]
        [MaxLength(5)]
        public int PostalCode { get; set; }
        [Display(Name = "Ville")]
        [MaxLength(30)]
        public string City { get; set; }

    }


}
