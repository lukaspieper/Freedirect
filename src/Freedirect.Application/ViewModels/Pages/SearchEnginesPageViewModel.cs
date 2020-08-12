using System.Collections.ObjectModel;
using System.Linq;
using Freedirect.Application.Settings;
using Freedirect.Application.Views;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Regions;

namespace Freedirect.Application.ViewModels.Pages
{
    [UsedImplicitly]
    internal class SearchEnginesPageViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserSettingsProvider _userSettingsProvider;
        private string _selectedSearchEngineName;

        internal SearchEnginesPageViewModel(IRegionManager regionManager, ISearchEnginesProvider searchEnginesProvider, IUserSettingsProvider userSettingsProvider)
        {
            _regionManager = regionManager;
            _userSettingsProvider = userSettingsProvider;
            NavigateToAboutCommand = new DelegateCommand(NavigateToAbout);

            SearchEnginesNames = new ObservableCollection<string>(
                searchEnginesProvider.SearchEngines.Select(searchEngine => searchEngine.Name));

            var appDataEntity = _userSettingsProvider.UserSettings;
            _selectedSearchEngineName = appDataEntity.SelectedSearchEngine;
        }

        public DelegateCommand NavigateToAboutCommand { get; }

        public ObservableCollection<string> SearchEnginesNames { get; }

        public string SelectedSearchEngineName
        {
            get => _selectedSearchEngineName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) return;

                SetProperty(ref _selectedSearchEngineName, value);
                SaveSelectedSearchEngine(value);
            }
        }

        private void SaveSelectedSearchEngine(string searchEngineName)
        {
            var appDataEntity = _userSettingsProvider.UserSettings;
            appDataEntity.SelectedSearchEngine = searchEngineName;

            _userSettingsProvider.UpdateUserSettings(appDataEntity);
        }

        private void NavigateToAbout()
        {
            _regionManager.RequestNavigate(NavigationNames.ContentRegion, NavigationNames.AboutPage);
        }
    }
}