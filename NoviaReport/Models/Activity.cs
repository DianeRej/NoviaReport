using System;

namespace NoviaReport.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public bool? Halfday { get; set; }
        public DateTime? Date { get; set; }
       
        public int TypeActivityId { get; set; }
        public TypeActivity TypeActivity { get; set; }

        /* public OtherActivities? OtherActivities { get; set; }
         public Absences? Absences { get; set; }
         public CustomersServices? CustomersServices { get; set; }*/
    }

   /* public enum OtherActivities
    {
        FORMATION_PROFESSIONNELLE, FORMATION_ECONOMIQUE_SOCIALE_ET_SYDICALE, INTER_CONTRAT
    }
    public enum Absences
    {
        CongéPayé, RTT, Conge_Sans_Solde, CongeMaternite, CongePaternite, CongéMaladie, AccidentDeTravail, AccidentDeTrajet, AutorisationDabsencePourExamensObligatoiresDeLaFemmeEnceinte,
        CongésPourEvènementsFamiliaux, Grève, ExamenMédicalDuTravail, CongéPourEnfantMalade, Crédits_dHeures_des_représentants_du_personnel, Congé_de_formation_des_membres_du_CSE
    }
    public enum CustomersServices
    {
        ASTREINTE, PRESTATION, MAINTENANCE
    }*/
}
