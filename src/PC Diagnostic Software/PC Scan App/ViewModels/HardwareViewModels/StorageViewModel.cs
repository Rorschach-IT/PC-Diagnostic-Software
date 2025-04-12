using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _storage;

        public ObservableCollection<KeyValuePair<string, string>> Storage
        {
            get => _storage;
            set
            {
                _storage = value;
                OnPropertyChanged(nameof(Storage));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public StorageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _storage = _mainViewModel.Storage;  // Bind to Storage data from MainViewModel

            // Trigger data loading manually if needed
            ShowStorageInfo = new RelayCommand(_ => _mainViewModel.LoadStorageData());
        }

        public ICommand ShowStorageInfo { get; }
    }
}
