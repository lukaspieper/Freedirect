using System;
using Freedirect.Core.ProtocolExtractor;
using Xunit;

namespace Freedirect.Tests.Core.ProtocolExtractor
{
    public class ProtocolExtractorFactoryTests
    {
        [Fact]
        public void CreateCorrespondingProtocolExtractor_CreatesEdgeProtocolUrlExtractor()
        {
            var validUri = new Uri("microsoft-edge:?launchContext1=...");
            var factory = new ProtocolExtractorFactory();

            var extractor = factory.CreateCorrespondingProtocolExtractor(validUri);

            Assert.IsType<EdgeProtocolExtractor>(extractor);
        }

        [Fact]
        public void CreateCorrespondingProtocolExtractor_ReturnsNull()
        {
            var invalidUri = new Uri("edge:?launchContext1=...");
            var factory = new ProtocolExtractorFactory();

            var extractor = factory.CreateCorrespondingProtocolExtractor(invalidUri);

            Assert.Null(extractor);
        }
    }
}