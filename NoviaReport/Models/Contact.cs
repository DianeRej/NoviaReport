using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Contact
    {
        public int Id { get; set; }
     
        [MaxLength(30)]
        public string PersonalMail { get; set; }
     
        public int PersonalPhone { get; set; }
        [MaxLength(30)]
        public string ProMail { get; set; }
      
        public int ProPhone { get; set; }

        public Adress Adress { get; set; }
        public int? AdressId { get; set; }


    }
}
