using System;
using Freedirect.Application.Configuration;
using Freedirect.Core;
using Freedirect.Core.ApplicationData;

namespace Freedirect.Application
{
    internal class UriService
    {
        public void TransformAndRunUri(Uri uri)
        {
            var protocolFacade = new ProtocolFacade();
            protocolFacade.CreateProtocol(uri.AbsoluteUri);

            var data = GetAppData();
            protocolFacade.UpdateConfig(data);

            protocolFacade.StartProtocol();

            System.Windows.Application.Current.Shutdown();
        }

        private AppData GetAppData()
        {
            var appDataProvider = new AppDataProvider();
            return appDataProvider.GetAppData();
        }
    }
}