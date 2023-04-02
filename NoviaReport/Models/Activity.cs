using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoviaReport.Models
{
    public class Activity
    {
        public int Id { get; set; }
        //boolean true = demi-journée, false (ou pas précisé) = journée complète
        //[Display(Name = "Demi-journée ?")]
        //public bool Halfday { get; set; }

        public DateTime Date { get; set; }
        [Display(Name = "Type d'Activité")]
        public TypeActivity TypeActivity { get; set; }
        //à préciser seulement si l'activité est une astreinte, prestation ou maintenance
        public Client? Client { get; set; }
    }

    public enum TypeActivity
    {
        [Display(Name = "Astreinte")] ASTREINTE,
        [Display(Name = "Prestation")] PRESTATION,
        [Display(Name = "Maintenance")] MAINTENANCE,
        [Display(Name = "Formation Professionnelle")] FORMATION_PROFESSIONNELLE,
        [Display(Name = "Formation Economique Sociale et Syndicale")] FORMATION_ECONOMIQUE_SOCIALE_ET_SYDICALE,
        [Display(Name = "Inter-Contrat")] INTER_CONTRAT,

        [Display(Name = "Congé Payé")] CONGE_PAYE,
        RTT,
        [Display(Name = "Congé Sans Solde")] CONGE_SANS_SOLDE,
        [Display(Name = "Congé Maternité")] CONGE_MATERNITE,
        [Display(Name = "Congé Paternité")] CONGE_PATERNITE,
        [Display(Name = "Congé Maladie")] CONGE_MALADIE,
        [Display(Name = "Accident de Travail")] ACCIDENT_DE_TRAVAIL,
        [Display(Name = "Accident de Trajet")] ACCIDENT_DE_TRAJET,
        [Display(Name = "Autorisation d'Absence Pour Examens Obligatoires de la Femme Enceinte")] AUTORISATION_EXAMENS_FEMME_ENCEINTE,
        [Display(Name = "Congé pour Evèvements Familiaux")] CONGE_EVENEMENTS_FAMILIAUX,
        [Display(Name = "Grève")] GREVE,
        [Display(Name = "Examen Médical du Travail")] EXAMEN_MEDICAL_DU_TRAVAIL,
        [Display(Name = "Congé pour Enfant Malade")] CONGE_ENFANT_MALADE,
        [Display(Name = "Crédits d'Heures des Représentants du Personnel")] CREDITS_HEURES_REP_PERSONNEL,
        [Display(Name = "Congé de Formation des Membres du CSE")] CONGE_FORMATION_CSE
    }

    public enum Client //trouver des noms d'entreprises fictives
    {
        [Display(Name = "Aucun client")] Aucun_Client,

        [Display(Name = "Société Générale")] SOCIETE_GENERALE,
        [Display(Name = "BNP Paribas")] BNP_PARIBAS,
        [Display(Name = "ENGIE")] ENGIE,
        [Display(Name = "Total Energies")] TOTAL_ENERGIES,
        [Display(Name = "Arkema")] ARKEMA,
        [Display(Name = "Elior Group")] ELIOR_GROUP,
        [Display(Name = "Eutelsat")] EUTELSAT,
        [Display(Name = "Vallourec")] VALLOUREC,
        [Display(Name = "Amoeba SA")] AMOEBA_SA
    }
}
