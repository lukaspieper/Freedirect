using System;
using Freedirect.Core.ApplicationData;
using Freedirect.Core.ProtocolExtractor;
using Freedirect.Core.ProtocolExtractor.Result;

namespace Freedirect.Core
{
    public class ProtocolFacade
    {
        private IProtocolExtractorResult _extractorResult;
        private UserSettings _data;

        public void CreateProtocol(Uri uri)
        {
            var extractorFactory = new ProtocolExtractorFactory();
            var extractor = extractorFactory.CreateCorrespondingProtocolExtractor(uri);

            _extractorResult = extractor?.Parse();
        }

        public void UpdateConfig(UserSettings data)
        {
            _data = data;
        }

        public void StartProtocol()
        {
            // TODO
            /*_extractorResult?.PrepareStart(_data);
            _extractorResult?.Start();*/
        }
    }
}
