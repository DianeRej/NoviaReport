namespace NoviaReport.Models
{
    public class OtherActivity : Activity
    {
        public OtherActivityType OtherActivityType { get; set; }
    }
    public enum OtherActivityType
    {
        FORMATION_PROFESSIONNELLE, FORMATION_ECONOMIQUE_SOCIALE_ET_SYDICALE, INTER_CONTRAT
    }
}
