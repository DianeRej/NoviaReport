﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Contact
    {
        //les display name correspondent aux noms qui seront affichés sur les vues
        public int Id { get; set; }

        [Display(Name = "Adresse Mail Personnelle")]

        public string PersonalMail { get; set; }

        [Display(Name = "Téléphone Personnel")]

        public int PersonalPhone { get; set; }

        [Display(Name = "Adresse Mail Pro")]

        public string ProMail { get; set; }

        [Display(Name = "Téléphone Pro")]

        public int ProPhone { get; set; }

        [Display(Name = "Rue")]
        public string Street { get; set; }

        [Display(Name = "Code Postal")]
        public int PostalCode { get; set; }

        [Display(Name = "Ville")]
        public string City { get; set; }



    }
}
