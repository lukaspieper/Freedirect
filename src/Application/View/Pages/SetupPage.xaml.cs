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
            Process.Start("ms-settings:defaultapps");
        }
    }
}
