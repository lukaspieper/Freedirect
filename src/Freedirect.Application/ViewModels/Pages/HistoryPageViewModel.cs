using System.Collections.ObjectModel;

namespace Freedirect.Application.ViewModels.Pages
{
    internal class HistoryPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> History { get; } = new ObservableCollection<string>();
    }
}