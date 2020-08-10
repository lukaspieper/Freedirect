using System;
using Freedirect.Core.Utilities;
using JetBrains.Annotations;
using Prism.Commands;

namespace Freedirect.Application.ViewModels.Pages
{
    [UsedImplicitly]
    internal class AboutPageViewModel : ViewModelBase
    {
        internal AboutPageViewModel()
        {
            OpenGitHubIssuesCommand = new DelegateCommand(OpenGitHubIssues);
        }

        public DelegateCommand OpenGitHubIssuesCommand { get; }

        private void OpenGitHubIssues()
        {
            var uri = new Uri("https://github.com/lukaspieper/Freedirect/issues");
            UriProcess.Start(uri);
        }
    }
}