using System.Collections.Generic;
using Freedirect.Application.UserSettings;
using Freedirect.Core.ApplicationData;

namespace Freedirect.Application.View.Pages
{
    internal partial class SearchEnginesPage
    {
        public List<string> SearchEnginesNames { get; set; } = new List<string>();
        private readonly SearchEngineProvider _searchEngineProvider = new SearchEngineProvider();
        private readonly UserSettingsProvider _userSettingsProvider = new UserSettingsProvider();

        public string SelectedSearchEngineName
        {
            get
            {
                var appDataEntity = _userSettingsProvider.UserSettings;
                return appDataEntity.SelectedSearchEngine;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) return;

                var appDataEntity = _userSettingsProvider.UserSettings;
                appDataEntity.SelectedSearchEngine = value;
                _userSettingsProvider.UpdateUserSettings(appDataEntity);
            }
        }

        public SearchEnginesPage()
        {
            foreach (var searchEngine in _searchEngineProvider.SearchEngines)
            {
                SearchEnginesNames.Add(searchEngine.Name);
            }

            InitializeComponent();
        }
    }
}
