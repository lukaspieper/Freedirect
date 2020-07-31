using System.Windows;
using Freedirect.Application.Views;
using Prism.Ioc;

namespace Freedirect.Application
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}