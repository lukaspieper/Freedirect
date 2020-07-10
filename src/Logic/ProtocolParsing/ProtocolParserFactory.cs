using System;

namespace Logic.ProtocolParsing
{
    internal class ProtocolParserFactory
    {
        private readonly string _scheme;
        private readonly string _protocolString;

        internal ProtocolParserFactory(string protocolString)
        {
            var firstColonIndex = protocolString.IndexOf(":", StringComparison.Ordinal);
            _scheme = protocolString.Substring(0, firstColonIndex);
            _protocolString = protocolString.Substring(firstColonIndex + 1);
        }

        internal IProtocolParser CreateProtocolParser()
        {
            IProtocolParser protocolParser;

            switch (_scheme)
            {
                case "microsoft-edge":
                    protocolParser = new EdgeProtocolParser(_protocolString);
                    break;
                default:
                    protocolParser = null;
                    break;
            }

            return protocolParser;
        }
    }
}