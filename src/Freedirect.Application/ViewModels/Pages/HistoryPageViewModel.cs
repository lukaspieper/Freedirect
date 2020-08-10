using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace Freedirect.Application.ViewModels.Pages
{
    [UsedImplicitly]
    internal class HistoryPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> History { get; } = new ObservableCollection<string>();
    }
}