using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class MemoryViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _memory;

        public ObservableCollection<KeyValuePair<string, string>> Memory
        {
            get => _memory;
            set
            {
                _memory = value;
                OnPropertyChanged(nameof(Memory));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public MemoryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _memory = _mainViewModel.Memory;  // Bind to Memory data from MainViewModel

            // Trigger data loading manually if needed
            ShowMemoryInfo = new RelayCommand(_ => _mainViewModel.LoadMemoryData());
        }

        public ICommand ShowMemoryInfo { get; }
    }
}
