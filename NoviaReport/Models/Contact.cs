using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Adresse Mail Personnelle")]
        
        public string PersonalMail { get; set; }

        [Display(Name = "Téléphone Personnel")]
        
        public int PersonalPhone { get; set; }

        [Display(Name = "Adresse Mail Pro")]
        
        public string ProMail { get; set; }

        [Display(Name = "Téléphone Pro")]
        
        public int ProPhone { get; set; }
        public Adress Adress { get; set; }
        public int? AdressId { get; set; }


    }
}
