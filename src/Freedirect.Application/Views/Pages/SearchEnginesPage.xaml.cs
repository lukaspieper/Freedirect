using System.Collections.Generic;
using Freedirect.Application.Data;
using Freedirect.Application.UserSettings;

namespace Freedirect.Application.Views.Pages
{
    internal partial class SearchEnginesPage
    {
        public List<string> SearchEnginesNames { get; set; } = new List<string>();
        private readonly SearchEnginesProvider _searchEnginesProvider = new SearchEnginesProvider();
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
            foreach (var searchEngine in _searchEnginesProvider.SearchEngines)
            {
                SearchEnginesNames.Add(searchEngine.Name);
            }

            InitializeComponent();
        }
    }
}
