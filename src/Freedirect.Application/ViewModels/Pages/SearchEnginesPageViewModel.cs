using System.Collections.ObjectModel;
using System.Linq;
using Freedirect.Application.Data;
using Freedirect.Application.UserSettings;
using Freedirect.Application.Views;
using Prism.Commands;
using Prism.Regions;

namespace Freedirect.Application.ViewModels.Pages
{
    internal class SearchEnginesPageViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly UserSettingsProvider _userSettingsProvider;
        private string _selectedSearchEngineName;

        internal SearchEnginesPageViewModel(IRegionManager regionManager, SearchEnginesProvider searchEnginesProvider, UserSettingsProvider userSettingsProvider)
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