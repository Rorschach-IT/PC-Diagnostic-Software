using PC_Scan_App.Models.HardwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class SystemViewModel : ViewModelBase
    {
        private SystemModel _system;
        public SystemModel SystemModel
        {
            get => _system;
            set
            {
                _system = value;
                OnPropertyChanged(nameof(System));
            }
        }

        public SystemViewModel()
        {
            _system = new SystemModel();
        }

        public void LoadSystemData()
        {
            SystemModel = Functions.SoftwareDataFetcher.GetOperatingSystemInfo();
        }
    }
}
