using System;
using Freedirect.Application.UserSettings;
using Freedirect.Core;

namespace Freedirect.Application
{
    internal class UriService
    {
        private readonly UserSettingsProvider _userSettingsProvider = new UserSettingsProvider();

        internal void TransformAndRunUri(Uri uri)
        {
            var protocolFacade = new ProtocolFacade();
            protocolFacade.ExtractProtocol(uri);

            protocolFacade.TransformProtocol(_userSettingsProvider.UserSettings);

            protocolFacade.StartProtocol();
        }
    }
}