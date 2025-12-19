using MultiTenantApp.ViewModels;
using System.Windows;

namespace MultiTenantApp.Views
{
    public partial class TenantSelectorWindow : Window
    {
        public TenantSelectorWindow(TenantSelectorViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}