using MultiTenantApp.Models;
using MultiTenantApp.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MultiTenantApp.Services.Implementations
{
    public class TenantService : ITenantService
    {
        private int _currentTenantId;
        private string _currentTenantName;

        public int CurrentTenantId
        {
            get => _currentTenantId;
            private set
            {
                if (_currentTenantId != value)
                {
                    _currentTenantId = value;
                    OnPropertyChanged(nameof(CurrentTenantId));
                }
            }
        }

        public string CurrentTenantName
        {
            get => _currentTenantName;
            private set
            {
                if (_currentTenantName != value)
                {
                    _currentTenantName = value;
                    OnPropertyChanged(nameof(CurrentTenantName));
                }
            }
        }

        public event EventHandler<TenantChangedEventArgs> TenantChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetTenant(int tenantId, string tenantName)
        {
            CurrentTenantId = tenantId;
            CurrentTenantName = tenantName;
            TenantChanged?.Invoke(this, new TenantChangedEventArgs
            {
                TenantId = tenantId,
                TenantName = tenantName
            });
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}