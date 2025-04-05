using PC_Scan_App.Models.HardwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class BiosViewModel : ViewModelBase
    {
        private BiosModel _bios;
        public BiosModel BiosModel
        {
            get => _bios;
            set
            {
                _bios = value;
                OnPropertyChanged(nameof(BiosModel));
            }
        }

        public BiosViewModel()
        {
            _bios = new BiosViewModel();
        }

        public void LoadBiosData()
        {
            BiosModel = Functions.SoftwareDataFetcher.GetBIOSInfo();
        }
    }
}
