namespace MultiTenantApp.Models
{
    public class TenantChangedEventArgs : EventArgs
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
    }
}