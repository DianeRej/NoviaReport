using System;
using System.Collections.Generic;

namespace NoviaReport.Models
{
    public class Activity
    {
        public int Id { get; set; }
        //boolean true = demi-journée, false = journée complète
        public bool? Halfday { get; set; }
        public DateTime Date { get; set; }
        public TypeActivity TypeActivity { get; set; }
        //à préciser seulement si l'activité est une astreinte, prestation ou maintenance
        public Client? Client { get; set; }
        public  List <CraActivity> Activities { get; set; }
    }

    public enum TypeActivity
    {
        FORMATION_PROFESSIONNELLE, FORMATION_ECONOMIQUE_SOCIALE_ET_SYDICALE, INTER_CONTRAT,

        CongéPayé, RTT, Conge_Sans_Solde, CongeMaternite, CongePaternite, CongéMaladie, AccidentDeTravail, AccidentDeTrajet, AutorisationDabsencePourExamensObligatoiresDeLaFemmeEnceinte,
        CongésPourEvènementsFamiliaux, Grève, ExamenMédicalDuTravail, CongéPourEnfantMalade, Crédits_dHeures_des_représentants_du_personnel, Congé_de_formation_des_membres_du_CSE,

        ASTREINTE, PRESTATION, MAINTENANCE
    }
    public enum Client
    {
        Client1, Client2, Client3, Client4, Client5, Client6
    }
}
