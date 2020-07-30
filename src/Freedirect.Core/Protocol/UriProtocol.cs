using System;
using System.Diagnostics;

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
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Uri.AbsoluteUri,
                UseShellExecute = true,
            };

            Process.Start(processStartInfo);
        }
    }
}