using RiftEngine.Frontend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RiftEngine.Frontend.Services
{
    public class NavigationService
    {
        private Frame _mainFrame;

        public void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            NavigateToDashboard();
        }

        public void NavigateToDashboard()
        {
            _mainFrame.Navigate(new DashboardView());
        }

        public void NavigateToGameConfig()
        {
            _mainFrame.Navigate(new GameConfigView());
        }

        public void NavigateToFileUnpack()
        {
            _mainFrame.Navigate(new FileUnpackView());
        }

        public void NavigateToSettings()
        {
            _mainFrame.Navigate(new SettingsView());
        }

        public void NavigateToEditor()
        {
            _mainFrame.Navigate(new EditorView());
        }
    }
}
