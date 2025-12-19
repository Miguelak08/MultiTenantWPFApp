using MultiTenantApp.Helpers;
using MultiTenantApp.Models;
using MultiTenantApp.Services.Interfaces;
using MultiTenantApp.Views;
using System.Windows;
using System.Windows.Input;

namespace MultiTenantApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITenantService _tenantService;
        private readonly ITenantConfigurationService _configService;
        private object _currentView;
        private string _logoUrl;

        public string CurrentTenantName => _tenantService.CurrentTenantName;

        public string LogoUrl
        {
            get => _logoUrl;
            set => SetProperty(ref _logoUrl, value);
        }

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ChangeTenantCommand { get; }

        public MainViewModel(ITenantService tenantService, ITenantConfigurationService configService)
        {
            _tenantService = tenantService;
            _configService = configService;

            ChangeTenantCommand = new RelayCommand(() => OpenTenantSelector());

            // Cargar la primera empresa por defecto
            _tenantService.SetTenant(1, "Empresa A");
            LoadTenantView(1);

            // Suscribirse a cambios de tenant
            _tenantService.TenantChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(CurrentTenantName));
                LoadTenantView(e.TenantId);
            };
        }

        private void LoadTenantView(int tenantId)
        {
            var config = _configService.GetConfiguration(tenantId);
            LogoUrl = config?.Logo;

            // Aquí cargarías el View principal para la empresa
            var view = new System.Windows.Controls.TextBlock
            {
                Text = $"Contenido de {config?.TenantName}\n\nEmpresas disponibles:\n- {string.Join("\n- ", config?.EnabledFeatures ?? new List<string>())}",
                FontSize = 18,
                Foreground = System.Windows.Media.Brushes.DarkGray,
                TextAlignment = System.Windows.TextAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };

            CurrentView = view;
        }

        private void OpenTenantSelector()
        {
            var selectorWindow = new TenantSelectorWindow(
                new TenantSelectorViewModel(_tenantService, _configService))
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            selectorWindow.ShowDialog();
        }
    }
}