using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class GraphicsCardViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _graphicsCards;

        public ObservableCollection<KeyValuePair<string, string>> GraphicsCards
        {
            get => _graphicsCards;
            set
            {
                _graphicsCards = value;
                OnPropertyChanged(nameof(GraphicsCards));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public GraphicsCardViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _graphicsCards = _mainViewModel.GraphicsCards; // Bind to GraphicsCards data from MainViewModel

            // Trigger data loading manually if needed
            ShowGraphicsCardInfo = new RelayCommand(_ => _mainViewModel.LoadGraphicsCardData());
        }

        public ICommand ShowGraphicsCardInfo { get; }
    }
}
