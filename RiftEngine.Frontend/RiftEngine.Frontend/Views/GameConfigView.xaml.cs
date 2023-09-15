using Microsoft.Extensions.DependencyInjection;
using RiftEngine.Frontend.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace RiftEngine.Frontend.Views
{
    /// <summary>
    /// Interaction logic for GameConfigView.xaml
    /// </summary>
    public partial class GameConfigView : Page
    {
        public GameConfigView()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).ServiceProvider.GetRequiredService<GameConfigViewModel>();
        }
    }
}
