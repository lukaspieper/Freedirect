using Logic.Protocol;

namespace Logic.ProtocolParsing
{
    internal class EdgeProtocolParser : IProtocolParser
    {
        private string _protocolCache;
        private readonly EdgeProtocol _edgeProtocol = new EdgeProtocol();

        public EdgeProtocolParser(string protocolString)
        {
            _protocolCache = protocolString;
        } 

        public void Parse()
        {
            if (UrlIsInQuery())
            {
                ParseQuery();
            }
            else
            {
                _edgeProtocol.Url = _protocolCache;
            }
        }

        private bool UrlIsInQuery()
        {
            return _protocolCache.StartsWith("?");
        }

        private void ParseQuery()
        {
            _protocolCache = _protocolCache.Substring(1); //remove '?'
            var parts = _protocolCache.Split('&');
            foreach (var part in parts)
            {
                if (part.StartsWith("url="))
                {
                    _edgeProtocol.Url = part.Substring(4);
                    break;
                }
            }
        }

        public IProtocol GetProtocol()
        {
            return _edgeProtocol;
        }
    }
}