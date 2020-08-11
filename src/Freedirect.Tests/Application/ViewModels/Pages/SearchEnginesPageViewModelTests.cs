using System.Collections.Generic;
using Freedirect.Application.Settings;
using Freedirect.Application.ViewModels.Pages;
using Freedirect.Core;
using NSubstitute;
using Xunit;

namespace Freedirect.Tests.Application.ViewModels.Pages
{
    public class SearchEnginesPageViewModelTests
    {
        private readonly ISearchEnginesProvider _searchEnginesProvider;
        private readonly IUserSettingsProvider _userSettingsProvider;

        public SearchEnginesPageViewModelTests()
        {
            _searchEnginesProvider = Substitute.For<ISearchEnginesProvider>();
            var searchEngines = new List<SearchEngine> { new SearchEngine("Example1", "https://example.com/") };
            _searchEnginesProvider.SearchEngines.Returns(searchEngines);

            var userSettings = new UserSettings { SelectedSearchEngine = "Example1" };
            _userSettingsProvider = new FakeUserSettingsProvider(userSettings);
        }

        [Fact]
        public void SearchEnginesNames_ContainsSampleNames()
        {
            var viewModel = new SearchEnginesPageViewModel(null, _searchEnginesProvider, _userSettingsProvider);

            var searchEngineNames = viewModel.SearchEnginesNames;

            Assert.Equal(new List<string> { "Example1" }, searchEngineNames);
        }

        [Fact]
        public void SelectedSearchEngineName_MatchesUserSettings()
        {
            var viewModel = new SearchEnginesPageViewModel(null, _searchEnginesProvider, _userSettingsProvider);

            var selectedSearchEngineName = viewModel.SelectedSearchEngineName;

            Assert.Equal("Example1", selectedSearchEngineName);
        }

        [Fact]
        public void SelectedSearchEngineName_SetName_UpdatesUserSettings()
        {
            var viewModel = new SearchEnginesPageViewModel(null, _searchEnginesProvider, _userSettingsProvider);

            viewModel.SelectedSearchEngineName = "ExpectedSearchEngine";

            Assert.Equal("ExpectedSearchEngine", _userSettingsProvider.UserSettings.SelectedSearchEngine);
        }
    }
}