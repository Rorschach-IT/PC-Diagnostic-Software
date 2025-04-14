// Ignore Spelling: App

using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class ProcessorViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _processor;

        public ObservableCollection<KeyValuePair<string, string>> Processor
        {
            get => _processor;
            set
            {
                _processor = value;
                OnPropertyChanged(nameof(Processor));
            }
        }

        // Assuming MainViewModel is passed in through the constructor
        private readonly MainViewModel _mainViewModel;

        public ProcessorViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _processor = _mainViewModel.Processor;  // Bind to Processor data from MainViewModel

            ShowProcessorInfo = new RelayCommand(_ => _mainViewModel.LoadProcessorData());
        }

        public ICommand ShowProcessorInfo { get; }
    }
}
