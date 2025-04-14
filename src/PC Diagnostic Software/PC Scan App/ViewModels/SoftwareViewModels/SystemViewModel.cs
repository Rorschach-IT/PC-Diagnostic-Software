// Ignore Spelling: App

using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class SystemViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _system;

        public ObservableCollection<KeyValuePair<string, string>> System
        {
            get => _system;
            set
            {
                _system = value;
                OnPropertyChanged(nameof(System));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public SystemViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _system = _mainViewModel.System; // Bind to the System data from MainViewModel

            ShowWindowsInfo = new RelayCommand(_ => _mainViewModel.LoadSystemData());
        }

        public ICommand ShowWindowsInfo { get; }
    }
}
