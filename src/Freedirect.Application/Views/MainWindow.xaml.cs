using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Freedirect.Application.Views.Pages;

namespace Freedirect.Application.Views
{
    internal partial class MainWindow
    {
        private readonly SetupPage _setupPage = new SetupPage();
        private readonly SearchEnginesPage _searchEnginesPage = new SearchEnginesPage();
        private readonly AboutPage _aboutPage = new AboutPage();
        private readonly HistoryPage _historyPage = new HistoryPage();

        public MainWindow()
        {
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();

            InitializeComponent();
            ContentFrame.Navigate(new SetupPage());
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton button)) return;
            var contentString = button.Content.ToString();

            if (contentString == Properties.Resources.Setup)
            {
                ContentFrame.Navigate(_setupPage);
            }
            else if (contentString == Properties.Resources.SearchEngine)
            {
                ContentFrame.Navigate(_searchEnginesPage);
            }
        }

        private void MenuItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;
            var tag = button.Tag.ToString();

            switch (tag)
            {
                case "About":
                    ContentFrame.Navigate(_aboutPage);
                    break;
                case "History":
                    ContentFrame.Navigate(_historyPage);
                    break;
            }

            Popup.IsOpen = false;
        }
    }
}