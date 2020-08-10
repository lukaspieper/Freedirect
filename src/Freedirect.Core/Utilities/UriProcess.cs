﻿using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Freedirect.Core.Utilities
{
    [UsedImplicitly]
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