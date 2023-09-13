using Microsoft.Extensions.DependencyInjection;
using RiftEngine.Frontend.Configurations;
using RiftEngine.Frontend.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RiftEngine.Frontend
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider = ServiceConfigurator.ConfigureServices();

            // Create a main window to host your MainView page
            var mainWindow = new MainWindow
            {
                Content = ServiceProvider.GetRequiredService<MainView>()
            };
            mainWindow.Show();
        }
    }
}
