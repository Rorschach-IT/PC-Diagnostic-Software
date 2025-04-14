// Ignore Spelling: App

using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class BiosViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _bios;

        public ObservableCollection<KeyValuePair<string, string>> Bios
        {
            get => _bios;
            set
            {
                _bios = value;
                OnPropertyChanged(nameof(Bios));
            }
        }

        private readonly MainViewModel _mainViewModel;

        public BiosViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _bios = _mainViewModel.Bios; // Bind to the BIOS data from MainViewModel

            ShowBiosInfo = new RelayCommand(_ => _mainViewModel.LoadBiosData()); // Trigger data loading in MainViewModel
        }

        public ICommand ShowBiosInfo { get; }
    }
}
