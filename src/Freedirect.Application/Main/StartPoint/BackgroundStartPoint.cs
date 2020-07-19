using System;
using Freedirect.Core;
using Freedirect.Core.ApplicationData;

namespace Freedirect.Application.Main.StartPoint
{
    internal class BackgroundStartPoint : IStartPoint
    {
        private readonly string _protocolString;

        internal BackgroundStartPoint(string protocolString)
        {
            _protocolString = Uri.UnescapeDataString(protocolString);
        }

        public void Start()
        {
            var protocolFacade = new ProtocolFacade();
            protocolFacade.CreateProtocol(_protocolString);

            var data = GetAppData();
            protocolFacade.UpdateConfig(data);

            protocolFacade.StartProtocol();

            System.Windows.Application.Current.Shutdown();
        }

        private AppDataEntity GetAppData()
        {
            var appDataProvider = new AppDataProvider();
            return appDataProvider.GetAppData();
        }
    }
}