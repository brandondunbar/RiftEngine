using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using RiftEngine.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RiftNavService = RiftEngine.Frontend.Services.NavigationService;

namespace RiftEngine.Frontend.ViewModels
{
    public class GameConfigViewModel
    {
        private readonly RiftNavService _navigationService;
        public ICommand SelectFilesCommand { get; }
        public ObservableCollection<string> AvailableGames { get; set; }
        private string config_path = "LibraryConfig.json";

        public GameConfigViewModel(RiftNavService navigationService)
        {
            _navigationService = navigationService;
            SelectFilesCommand = new RelayCommand(SelectFilesButton_Clicked);
            AvailableGames = new ObservableCollection<string>();
            LoadLibraryConfig();
        }

        public void SelectFilesButton_Clicked()
        {
            _navigationService.NavigateToFileUnpack();
        }

        private void LoadLibraryConfig()
        {
            var libraryModels = LoadLibraryConfig(config_path);
            foreach (var library in libraryModels)
            {
                foreach (var game in library.SupportedGames)
                {
                    AvailableGames.Add(game);
                }
            }
        }

        private List<LibraryModel> LoadLibraryConfig(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<LibraryModel>>(json);
        }
    }
}
