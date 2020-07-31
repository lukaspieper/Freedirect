using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolTransformer
{
    internal class ProtocolTransformerFactory
    {
        internal IProtocolTransformer CreateCorrespondingProtocolTransformer(IProtocol protocol, SearchEngine searchEngine = null)
        {
            return protocol switch
            {
                UriProtocol uriProtocol => new SearchEngineTransformer(uriProtocol, searchEngine),
                _ => null,
            };
        }
    }
}