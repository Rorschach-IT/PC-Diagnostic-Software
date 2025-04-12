using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class MotherboardViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _motherboard;

        public ObservableCollection<KeyValuePair<string, string>> Motherboard
        {
            get => _motherboard;
            set
            {
                _motherboard = value;
                OnPropertyChanged(nameof(Motherboard));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public MotherboardViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _motherboard = _mainViewModel.Motherboard; // Bind to Motherboard data from MainViewModel

            // Trigger data loading manually if needed
            ShowMotherboardInfo = new RelayCommand(_ => _mainViewModel.LoadMotherboardData());
        }

        public ICommand ShowMotherboardInfo { get; }
    }
}
