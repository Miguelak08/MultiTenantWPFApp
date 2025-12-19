namespace MultiTenantApp.Models
{
    public class TenantConfiguration
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Logo { get; set; }
        public List<string> EnabledFeatures { get; set; }
    }
}