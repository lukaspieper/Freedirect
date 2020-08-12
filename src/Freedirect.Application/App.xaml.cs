using System.Windows;
using Freedirect.Application.Settings;
using Freedirect.Application.Views;
using Freedirect.Application.Views.Pages;
using Prism.Ioc;

namespace Freedirect.Application
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SetupPage>(NavigationNames.SetupPage);
            containerRegistry.RegisterForNavigation<SearchEnginesPage>(NavigationNames.SearchEnginesPage);
            containerRegistry.RegisterForNavigation<HistoryPage>(NavigationNames.HistoryPage);
            containerRegistry.RegisterForNavigation<AboutPage>(NavigationNames.AboutPage);

            containerRegistry.RegisterSingleton<ISearchEnginesProvider, SearchEnginesProvider>();
            containerRegistry.RegisterSingleton<IUserSettingsProvider, UserSettingsProvider>();
        }
    }
}