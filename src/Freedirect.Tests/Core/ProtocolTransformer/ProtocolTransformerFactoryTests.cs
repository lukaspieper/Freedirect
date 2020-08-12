using Freedirect.Core.Protocol;
using Freedirect.Core.ProtocolTransformer;
using Xunit;

namespace Freedirect.Tests.Core.ProtocolTransformer
{
    public class ProtocolTransformerFactoryTests
    {
        [Fact]
        public void CreateCorrespondingProtocolTransformer_CreatesSearchEngineTransformer()
        {
            var validProtocol = new UriProtocol(null);
            var factory = new ProtocolTransformerFactory();

            var transformer = factory.CreateCorrespondingProtocolTransformer(validProtocol);

            Assert.IsType<SearchEngineTransformer>(transformer);
        }
    }
}