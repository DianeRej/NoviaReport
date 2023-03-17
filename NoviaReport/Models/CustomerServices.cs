namespace NoviaReport.Models
{
    public class CustomerServices : Activity
    {
        public CustomerServicesType CustomerServicesType { get; set; }
       
    }

    public enum CustomerServicesType
    {
        ASTREINTE, PRESTATION, MAINTENANCE
    }
}
