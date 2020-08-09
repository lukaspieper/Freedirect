using System;
using System.Diagnostics;

namespace Freedirect.Core.Utilities
{
    public class UriProcess : Process
    {
        public static void Start(Uri uri)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = uri.AbsoluteUri,
                UseShellExecute = true,
            };
            Start(processStartInfo);
        }
    }
}