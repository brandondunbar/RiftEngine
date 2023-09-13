using Microsoft.Extensions.DependencyInjection;
using RiftEngine.Frontend.Views;
using RiftEngine.Frontend.ViewModels;
using RiftEngine.Frontend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // Register ViewModels
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<GameConfigViewModel>();
            services.AddTransient<MainViewModel>();

            // Register Views
            services.AddTransient<MainView>();
            services.AddTransient<DashboardView>();

            return services.BuildServiceProvider();
        }
    }

}
