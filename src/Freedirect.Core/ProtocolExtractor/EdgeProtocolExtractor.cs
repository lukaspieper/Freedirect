using System;
using System.Linq;
using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolExtractor
{
    internal class EdgeProtocolExtractor : IProtocolExtractor
    {
        private readonly Uri _uri;

        public EdgeProtocolExtractor(Uri uri)
        {
            _uri = uri;
        }

        public IProtocol Parse()
        {
            var url = IsUrlInQuery() ? ParseUrlFromQuery() : new Uri(_uri.LocalPath);

            return url != null ? new UriProtocol(url) : null;
        }

        private bool IsUrlInQuery()
        {
            return string.IsNullOrWhiteSpace(_uri.LocalPath) && !string.IsNullOrWhiteSpace(_uri.Query);
        }

        private Uri ParseUrlFromQuery()
        {
            var urlPart = _uri.Query.Split('&')
                .FirstOrDefault(part => part.StartsWith("url=", StringComparison.OrdinalIgnoreCase));

            return urlPart != null ? new Uri(urlPart.Substring(4)) : null;
        }
    }
}