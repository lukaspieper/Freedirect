using System.Collections.ObjectModel;
using System.Linq;
using Freedirect.Application.Data;
using Freedirect.Application.UserSettings;

namespace Freedirect.Application.ViewModels.Pages
{
    internal class SearchEnginesPageViewModel : ViewModelBase
    {
        private readonly UserSettingsProvider _userSettingsProvider;
        private string _selectedSearchEngineName;

        internal SearchEnginesPageViewModel(SearchEnginesProvider searchEnginesProvider, UserSettingsProvider userSettingsProvider)
        {
            _userSettingsProvider = userSettingsProvider;

            SearchEnginesNames = new ObservableCollection<string>(
                searchEnginesProvider.SearchEngines.Select(searchEngine => searchEngine.Name));

            var appDataEntity = _userSettingsProvider.UserSettings;
            _selectedSearchEngineName = appDataEntity.SelectedSearchEngine;
        }

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
    }
}