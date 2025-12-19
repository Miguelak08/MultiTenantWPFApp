using Microsoft.Extensions.DependencyInjection;
using MultiTenantApp.Services.Implementations;
using MultiTenantApp.Services.Interfaces;
using MultiTenantApp.Views;
using System.Windows;

namespace MultiTenantApp
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            // Registrar servicios
            services.AddSingleton<ITenantService, TenantService>();
            services.AddSingleton<ITenantConfigurationService, TenantConfigurationService>();

            // Registrar Views
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}