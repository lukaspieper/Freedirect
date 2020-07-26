using System;
using System.Collections.Generic;

namespace Freedirect.Application
{
    internal class Program
    {
        [STAThread]
        internal static void Main(string[] args)
        {
            var uri = GetUriFromArgs(args);

            if (uri != null)
            {
                var service = new UriService();
                service.TransformAndRunUri(uri);
            }
            else
            {
                ShowUi();
            }
        }

        private static Uri GetUriFromArgs(IReadOnlyList<string> args)
        {
            try
            {
                var unescapedString = Uri.UnescapeDataString(args[0]);
                return new Uri(unescapedString);
            }
            catch (Exception)
            {
                // Catching general exception because specific cases are not handled separately.
            }

            return null;
        }

        private static void ShowUi()
        {
            // Change the language for checking localization.
            // System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}