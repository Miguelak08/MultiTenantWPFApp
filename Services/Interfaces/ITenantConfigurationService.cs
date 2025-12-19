using MultiTenantApp.Models;

namespace MultiTenantApp.Services.Interfaces
{
    public interface ITenantConfigurationService
    {
        TenantConfiguration GetConfiguration(int tenantId);
        void LoadConfiguration(int tenantId);
    }
}