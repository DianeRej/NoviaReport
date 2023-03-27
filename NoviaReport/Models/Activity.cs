using System;

namespace NoviaReport.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public bool? Halfday { get; set; }
        public DateTime? Date { get; set; }
        public TypeActivity TypeActivity { get; set; }
       
       
    }

    public enum TypeActivity
    {
        FORMATION_PROFESSIONNELLE, FORMATION_ECONOMIQUE_SOCIALE_ET_SYDICALE, INTER_CONTRAT,

        CongéPayé, RTT, Conge_Sans_Solde, CongeMaternite, CongePaternite, CongéMaladie, AccidentDeTravail, AccidentDeTrajet, AutorisationDabsencePourExamensObligatoiresDeLaFemmeEnceinte,
        CongésPourEvènementsFamiliaux, Grève, ExamenMédicalDuTravail, CongéPourEnfantMalade, Crédits_dHeures_des_représentants_du_personnel, Congé_de_formation_des_membres_du_CSE,

        ASTREINTE, PRESTATION, MAINTENANCE
    }

}
