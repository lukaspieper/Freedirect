using Freedirect.Application.View;

namespace Freedirect.Application.Main.StartPoint
{
    internal class ForegroundStartPoint : IStartPoint
    {
        public void Start()
        {
            //Change the language for testing 
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            var window = new MainWindow();
            window.Show();
        }
    }
}