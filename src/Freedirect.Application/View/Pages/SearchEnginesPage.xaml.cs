using System.Collections.Generic;
using Freedirect.Core.ApplicationData;

namespace Freedirect.Application.View.Pages
{
    internal partial class SearchEnginesPage
    {
        public List<string> SearchEnginesNames { get; set; } = new List<string>();
        private readonly SearchEngineProvider _searchEngineProvider = new SearchEngineProvider();
        private readonly AppDataProvider _appDataProvider = new AppDataProvider();

        public string SelectedSearchEngineName
        {
            get
            {
                var appDataEntity = _appDataProvider.GetAppData();
                return appDataEntity.SearchEngineName;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) return;

                var appDataEntity = _appDataProvider.GetAppData();
                appDataEntity.SearchEngineName = value;
                _appDataProvider.UpdateAppData(appDataEntity);
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
