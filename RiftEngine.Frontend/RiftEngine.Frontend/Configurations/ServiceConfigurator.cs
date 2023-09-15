using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RiftEngine.Frontend;
using RiftEngine.Frontend.DataModels;
using RiftEngine.Frontend.Models;
using RiftEngine.Frontend.Services;
using RiftEngine.Frontend.Views;
using RiftEngine.Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RiftEngine.Frontend.Configurations
{
    public class ServiceConfigurator
    {
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
            if (File.Exists("GameConfig.json"))
            {
                string json = File.ReadAllText("GameConfig.json");
                GameConfig _loadedGameConfig = JsonConvert.DeserializeObject<GameConfig>(json);
                return _loadedGameConfig;
            }
            else
            {
                // Create a new GameConfig with default values
                GameConfig newConfig = new GameConfig { AddedGames = new List<GameModel>() };

                // Serialize it to a JSON file
                string json = JsonConvert.SerializeObject(newConfig, Formatting.Indented);
                File.WriteAllText("GameConfig.json", json);

                return newConfig;
            }
        }
    }
}
