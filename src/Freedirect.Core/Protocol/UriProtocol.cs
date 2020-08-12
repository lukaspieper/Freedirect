using System;
using Freedirect.Core.Utilities;

namespace Freedirect.Core.Protocol
{
    internal class UriProtocol : IProtocol
    {
        internal UriProtocol(Uri uri)
        {
            Uri = uri;
        }

        internal Uri Uri { get; }

        public void Start()
        {
            UriProcess.Start(Uri);
        }
    }
}