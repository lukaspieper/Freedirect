using System;
using Freedirect.Core.Protocol;
using Freedirect.Core.ProtocolExtractor;
using Freedirect.Core.ProtocolTransformer;

namespace Freedirect.Core
{
    public class ProtocolFacade
    {
        private readonly ProtocolExtractorFactory _extractorFactory = new ProtocolExtractorFactory();
        private readonly ProtocolTransformerFactory _transformerFactory = new ProtocolTransformerFactory();
        private IProtocol _protocol;

        public void ExtractProtocol(Uri uri)
        {
            var extractor = _extractorFactory.CreateCorrespondingProtocolExtractor(uri);
            _protocol = extractor?.Parse();
        }

        public void TransformProtocol(SearchEngine searchEngine)
        {
            var transformer = _transformerFactory.CreateCorrespondingProtocolTransformer(_protocol, searchEngine);
            _protocol = transformer?.Transform();
        }

        public void StartProtocol()
        {
            _protocol?.Start();
        }
    }
}
