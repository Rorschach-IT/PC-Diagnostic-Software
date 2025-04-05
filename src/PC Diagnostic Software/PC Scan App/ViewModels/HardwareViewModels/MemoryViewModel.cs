using PC_Scan_App.Models.SoftwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class MemoryViewModel : ViewModelBase
    {
        private List<MemoryModel> _memory;
        public List<MemoryModel> MemoryModel
        {
            get => _memory;
            set
            {
                _memory = value;
                OnPropertyChanged(nameof(MemoryModel));
            }
        }

        public MemoryViewModel()
        {
            _memory = [];
        }

        public void LoadMemoryData()
        {
            MemoryModel = Functions.HardwareDataFetcher.GetMemoryInfo();
        }
    }
}
