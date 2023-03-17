using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Contact
    {
        public int Id { get; set; }
     
        [MaxLength(30)]
        public string PersonalMail { get; set; }
        [MaxLength(20)]
        public string PersonalPhone { get; set; }
        [MaxLength(30)]
        public string ProMail { get; set; }
        [MaxLength(20)]
        public string ProPhone { get; set; }

        public Adress Adress { get; set; }
        public int? AdressId { get; set; }


    }
}
