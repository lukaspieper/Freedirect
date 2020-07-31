using System;
using Freedirect.Application.Data;
using Freedirect.Application.UserSettings;
using Freedirect.Core;

namespace Freedirect.Application
{
    internal class UriService
    {
        private readonly UserSettingsProvider _userSettingsProvider = new UserSettingsProvider();
        private readonly SearchEnginesProvider _searchEnginesProvider = new SearchEnginesProvider();

        internal void TransformAndRunUri(Uri uri)
        {
            var protocolHandler = new ProtocolHandler();

            protocolHandler.ExtractProtocol(uri);

            var searchEngineName = _userSettingsProvider.UserSettings.SelectedSearchEngine;
            var searchEngine = _searchEnginesProvider.GetSearchEngineByName(searchEngineName);
            protocolHandler.TransformProtocol(searchEngine);

            protocolHandler.StartProtocol();
        }
    }
}