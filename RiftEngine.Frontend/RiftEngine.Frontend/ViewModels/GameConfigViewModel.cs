using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using RiftEngine.Frontend.DataModels;
using RiftEngine.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RiftNavService = RiftEngine.Frontend.Services.NavigationService;

namespace RiftEngine.Frontend.ViewModels
{
    public class GameConfigViewModel : INotifyPropertyChanged
    {
        // Nav attributes
        private readonly RiftNavService _navigationService;
        public ICommand SelectFilesCommand { get; }
        // Game attributes
        private readonly GameConfig _gameConfig;
        public ObservableCollection<string> AvailableGames { get; set; }
        // Config file attributes
        private readonly string LIBRARY_CONFIG_PATH = "LibraryConfig.json";
        private readonly string GAME_CONFIG_PATH = "GameConfig.json";
        // Front end binding attributes
        public event PropertyChangedEventHandler PropertyChanged;

        public GameConfigViewModel(RiftNavService navigationService, GameConfig gameConfig)
        {
            _navigationService = navigationService;
            SelectFilesCommand = new RelayCommand(SelectFilesButton_Clicked);
            AvailableGames = new ObservableCollection<string>();
            _gameConfig = gameConfig;
            if(_gameConfig.AddedGames == null)
            {
                _gameConfig.AddedGames = new List<GameModel>();
            }
            LoadLibraryConfig();
        }

        public void SelectFilesButton_Clicked()
        {
            // Update the GameModel
            var gameModel = GetGameModelByName(_selectedGame);
            if (gameModel != null)
            {
                gameModel.InstallPath = this.InstallPath;
                gameModel.UnpackToPath = this.UnpackToPath;
            }
            else
            {
                // Create a new GameModel and add it to _gameConfig.AddedGames
                var newGameModel = new GameModel
                {
                    Name = _selectedGame,
                    InstallPath = this.InstallPath,
                    UnpackToPath = this.UnpackToPath
                };
                _gameConfig.AddedGames.Add(newGameModel);
            }

            // Save the updated GameConfig
            SaveGameConfig();

            // Navigate to the next view
            _navigationService.NavigateToFileUnpack();
        }

        private void LoadLibraryConfig()
        {
            var libraryModels = LoadLibraryConfig(LIBRARY_CONFIG_PATH);
            foreach (var library in libraryModels)
            {
                foreach (var game in library.SupportedGames)
                {
                    AvailableGames.Add(game);
                }
            }
        }

        private void SaveGameConfig()
        {
            string json = JsonConvert.SerializeObject(_gameConfig);
            File.WriteAllText(GAME_CONFIG_PATH, json);
        }

        private static List<LibraryModel> LoadLibraryConfig(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<LibraryModel>>(json);
        }

        private GameModel? GetGameModelByName(string gameName)
        {
            if (_gameConfig?.AddedGames == null)
            {
                return null;
            }

            return _gameConfig.AddedGames.FirstOrDefault(g => g.Name == gameName);
        }

        private void UpdateTextBoxes()
        {
            var gameModel = GetGameModelByName(_selectedGame);
            if (gameModel != null)
            {
                // Update the textboxes
                this.InstallPath = gameModel.InstallPath;
                this.UnpackToPath = gameModel.UnpackToPath;
            }
            else
            {
                // TODO: Handle the case where no matching game model is found
                this.InstallPath = "";
                this.UnpackToPath = "";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Accessible attributes
        private string _selectedGame;
        public string SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                UpdateTextBoxes();
            }
        }

        private string _installPath;
        public string InstallPath
        {
            get { return _installPath; }
            set
            {
                _installPath = value;
                OnPropertyChanged(nameof(InstallPath));
            }
        }

        private string _unpackToPath;
        public string UnpackToPath
        {
            get { return _unpackToPath; }
            set
            {
                _unpackToPath = value;
                OnPropertyChanged(nameof(UnpackToPath));
            }
        }
    }
}
