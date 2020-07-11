using System.Diagnostics;

namespace Application.View.Pages
{
    internal partial class SetupPage
    {
        internal SetupPage()
        {
            InitializeComponent();
        }

        private void OpenDefaultAppsSettings(object sender, System.Windows.RoutedEventArgs e)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "ms-settings:defaultapps",
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }
    }
}
