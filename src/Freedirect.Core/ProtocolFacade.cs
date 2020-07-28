using Freedirect.Core.ApplicationData;
using Freedirect.Core.Protocol;
using Freedirect.Core.ProtocolParsing;

namespace Freedirect.Core
{
    public class ProtocolFacade
    {
        private IProtocol _protocol;
        private UserSettings _data;

        public void CreateProtocol(string protocolString)
        {
            var parser = CreateProtocolParser(protocolString);

            if (parser is null) return;

            parser.Parse();
            _protocol = parser.GetProtocol();
        }

        private IProtocolParser CreateProtocolParser(string protocolString)
        {
            var factory = new ProtocolParserFactory(protocolString);
            return factory.CreateProtocolParser();
        }

        public void UpdateConfig(UserSettings data)
        {
            _data = data;
        }

        public void StartProtocol()
        {
            _protocol?.PrepareStart(_data);
            _protocol?.Start();
        }
    }
}
