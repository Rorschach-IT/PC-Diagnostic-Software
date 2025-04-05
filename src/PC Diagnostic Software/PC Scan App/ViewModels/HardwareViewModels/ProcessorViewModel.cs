using PC_Scan_App.Models.SoftwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class ProcessorViewModel : ViewModelBase
    {
        private ProcessorModel _processor;
        public ProcessorModel ProcessorModel
        {
            get => _processor;
            set
            {
                _processor = value;
                OnPropertyChanged(nameof(ProcessorModel));
            }
        }

        public ProcessorViewModel()
        {
            _processor = new ProcessorModel();
        }

        public void LoadProcessorData()
        {
            ProcessorModel = Functions.HardwareDataFetcher.GetProcessorInfo();
        }
    }
}
