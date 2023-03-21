using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "Adresse Mail Personnelle")]
        [MaxLength(30)]
        public string PersonalMail { get; set; }
        [Display(Name = "Téléphone Personnel")]
        [MaxLength(10)]
        public int PersonalPhone { get; set; }
        [Display(Name = "Adresse Mail Pro")]
        [MaxLength(30)]
        public string ProMail { get; set; }
        [Display(Name = "Téléphone Pro")]
        [MaxLength(10)]
        public int ProPhone { get; set; }

        public Adress Adress { get; set; }
        public int? AdressId { get; set; }


    }
}
