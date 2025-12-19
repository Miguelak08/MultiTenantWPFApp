using MultiTenantApp.Helpers;
using MultiTenantApp.Models;
using MultiTenantApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MultiTenantApp.ViewModels
{
    public class TenantSelectorViewModel : ViewModelBase
    {
        private readonly ITenantService _tenantService;
        private readonly ITenantConfigurationService _configService;
        private ObservableCollection<TenantConfiguration> _tenants;

        public ObservableCollection<TenantConfiguration> Tenants
        {
            get => _tenants;
            set => SetProperty(ref _tenants, value);
        }

        public ICommand SelectTenantCommand { get; }

        public TenantSelectorViewModel(ITenantService tenantService, ITenantConfigurationService configService)
        {
            _tenantService = tenantService;
            _configService = configService;

            SelectTenantCommand = new RelayCommand<int>(SelectTenant);

            LoadTenants();
        }

        private void LoadTenants()
        {
            Tenants = new ObservableCollection<TenantConfiguration>
            {
                _configService.GetConfiguration(1),
                _configService.GetConfiguration(2)
            };
        }

        private void SelectTenant(int tenantId)
        {
            var config = _configService.GetConfiguration(tenantId);
            if (config != null)
            {
                _tenantService.SetTenant(tenantId, config.TenantName);

                // Cerrar la ventana
                if (Application.Current.Windows.Count > 1)
                {
                    var window = Application.Current.Windows[Application.Current.Windows.Count - 1];
                    window?.Close();
                }
            }
        }
    }
}
