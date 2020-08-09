using System;
using Freedirect.Core.Utilities;
using JetBrains.Annotations;
using Prism.Commands;

namespace Freedirect.Application.ViewModels.Pages
{
    [UsedImplicitly]
    internal class SetupPageViewModel : ViewModelBase
    {
        internal SetupPageViewModel()
        {
            OpenDefaultAppsSettingsCommand = new DelegateCommand<string>(OpenDefaultAppsSettings);
        }

        public DelegateCommand<string> OpenDefaultAppsSettingsCommand { get; }

        private void OpenDefaultAppsSettings(string obj)
        {
            var uri = new Uri("ms-settings:defaultapps");
            UriProcess.Start(uri);
        }
    }
}