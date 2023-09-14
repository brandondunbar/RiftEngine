using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RiftNavService = RiftEngine.Frontend.Services.NavigationService;

namespace RiftEngine.Frontend.ViewModels
{
    public class DashboardViewModel
    {
        private readonly RiftNavService _navigationService;
        public ICommand AddGameCommand { get; }

        public DashboardViewModel(RiftNavService navigationService)
        {
            _navigationService = navigationService;
            AddGameCommand = new RelayCommand(AddGameButton_Clicked);
        }

        public void AddGameButton_Clicked()
        {
            _navigationService.NavigateToGameConfig();
        }
    }
}
