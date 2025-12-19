using MultiTenantApp.Services.Interfaces;
using MultiTenantApp.ViewModels;
using System.Windows;

namespace MultiTenantApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly ITenantService _tenantService;
        private readonly ITenantConfigurationService _configService;

        public MainWindow(ITenantService tenantService, ITenantConfigurationService configService)
        {
            InitializeComponent();

            _tenantService = tenantService;
            _configService = configService;

            this.DataContext = new MainViewModel(tenantService, configService);

            _tenantService.TenantChanged += OnTenantChanged;
        }

        private void OnTenantChanged(object sender, Models.TenantChangedEventArgs e)
        {
            _configService.LoadConfiguration(e.TenantId);
        }
    }
}