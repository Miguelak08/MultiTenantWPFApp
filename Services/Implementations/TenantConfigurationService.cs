using MultiTenantApp.Models;
using MultiTenantApp.Services.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace MultiTenantApp.Services.Implementations
{
    public class TenantConfigurationService : ITenantConfigurationService
    {
        private readonly Dictionary<int, TenantConfiguration> _configurations;

        public TenantConfigurationService()
        {
            _configurations = new Dictionary<int, TenantConfiguration>
            {
                { 1, new TenantConfiguration
                {
                    TenantId = 1,
                    TenantName = "Empresa A",
                    PrimaryColor = "#FF0066CC",
                    SecondaryColor = "#FF003366",
                    Logo = "pack://application:,,,/Resources/LogoA.png",
                    EnabledFeatures = new List<string> { "Reports", "Analytics", "Inventory" }
                }},
                { 2, new TenantConfiguration
                {
                    TenantId = 2,
                    TenantName = "Empresa B",
                    PrimaryColor = "#FF009900",
                    SecondaryColor = "#FF006600",
                    Logo = "pack://application:,,,/Resources/LogoB.png",
                    EnabledFeatures = new List<string> { "Reports", "CRM" }
                }}
            };
        }

        public TenantConfiguration GetConfiguration(int tenantId)
        {
            return _configurations.ContainsKey(tenantId)
                ? _configurations[tenantId]
                : null;
        }

        public void LoadConfiguration(int tenantId)
        {
            var config = GetConfiguration(tenantId);
            if (config != null)
            {
                ApplyTheme(config);
            }
        }

        private void ApplyTheme(TenantConfiguration config)
        {
            var app = Application.Current;
            var converter = new BrushConverter();

            app.Resources["PrimaryColor"] = converter.ConvertFrom(config.PrimaryColor);
            app.Resources["SecondaryColor"] = converter.ConvertFrom(config.SecondaryColor);
        }
    }
}