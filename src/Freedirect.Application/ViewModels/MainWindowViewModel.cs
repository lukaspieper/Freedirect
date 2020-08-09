using System.Windows.Input;
using Freedirect.Application.Views;
using Prism.Commands;
using Prism.Regions;

namespace Freedirect.Application.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private bool _secondaryMenuIsShown;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public bool SecondaryMenuIsShown
        {
            get => _secondaryMenuIsShown;
            set => SetProperty(ref _secondaryMenuIsShown, value);
        }

        private void Navigate(string navigationTargetName)
        {
            if (navigationTargetName == null) return;

            _regionManager.RequestNavigate(NavigationNames.ContentRegion, navigationTargetName);
            SecondaryMenuIsShown = false;
        }
    }
}