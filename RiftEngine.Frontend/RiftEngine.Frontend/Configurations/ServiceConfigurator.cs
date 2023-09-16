using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RiftEngine.Frontend;
using RiftEngine.Frontend.Common;
using RiftEngine.Frontend.DataModels;
using RiftEngine.Frontend.Models;
using RiftEngine.Frontend.Services;
using RiftEngine.Frontend.Views;
using RiftEngine.Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace RiftEngine.Frontend.Configurations
{
    public class ServiceConfigurator
    {
        // Config paths
        private static string GAME_CONFIG_PATH = Constants.GameConfigPath;

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<NavigationService>();

            // Register Data Models
            services.AddSingleton(LoadGameConfig());

            // Register ViewModels
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<GameConfigViewModel>();
            services.AddTransient<MainViewModel>();

            // Register Views
            services.AddTransient<MainView>();
            services.AddTransient<DashboardView>();

            return services.BuildServiceProvider();
        }

        public static GameConfig LoadGameConfig()
        {
            if (File.Exists(GAME_CONFIG_PATH))
            {
                string json = File.ReadAllText(GAME_CONFIG_PATH);
                GameConfig _loadedGameConfig = JsonConvert.DeserializeObject<GameConfig>(json);
                return _loadedGameConfig;
            }
            else
            {
                // Create a new GameConfig with default values
                GameConfig newConfig = new() { AddedGames = new List<GameModel>() };

                // Serialize it to a JSON file
                string json = JsonConvert.SerializeObject(newConfig, Formatting.Indented);
                File.WriteAllText(GAME_CONFIG_PATH, json);

                return newConfig;
            }
        }
    }
}
