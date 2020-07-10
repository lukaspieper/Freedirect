using Logic.ApplicationData;
using Logic.Protocol;
using Logic.ProtocolParsing;

namespace Logic
{
    public class ProtocolFacade
    {
        private IProtocol _protocol;
        private AppDataEntity _dataEntity;

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

        public void UpdateConfig(AppDataEntity dataEntity)
        {
            _dataEntity = dataEntity;
        }

        public void StartProtocol()
        {
            _protocol?.PrepareStart(_dataEntity);
            _protocol?.Start();
        }
    }
}
