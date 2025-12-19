using MultiTenantApp.Models;
using System.ComponentModel;

namespace MultiTenantApp.Services.Interfaces
{
    public interface ITenantService : INotifyPropertyChanged
    {
        int CurrentTenantId { get; }
        string CurrentTenantName { get; }
        void SetTenant(int tenantId, string tenantName);
        event EventHandler<TenantChangedEventArgs> TenantChanged;
    }
}