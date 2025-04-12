using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
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

        // Assuming the MainViewModel instance is passed via constructor (or you can use DI)
        private readonly MainViewModel _mainViewModel;

        public ProcessorViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _processor = _mainViewModel.Processor;  // Bind to Processor data from MainViewModel

            // If you need to trigger data loading manually
            ShowProcessorInfo = new RelayCommand(_ => _mainViewModel.LoadProcessorData());
        }

        public ICommand ShowProcessorInfo { get; }
    }
}
