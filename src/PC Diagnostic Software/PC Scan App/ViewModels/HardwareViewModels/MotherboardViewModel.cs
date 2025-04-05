using PC_Scan_App.Models.SoftwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class MotherboardViewModel : ViewModelBase
    {
        private MotherboardModel _motherboard;
        public MotherboardModel MotherboardModel
        {
            get => _motherboard;
            set
            {
                _motherboard = value;
                OnPropertyChanged(nameof(MotherboardModel));
            }
        }

        public MotherboardViewModel()
        {
            _motherboard = new MotherboardModel();
        }

        public void LoadMotherboardData()
        {
            MotherboardModel = Functions.HardwareDataFetcher.GetMotherboardInfo();
        }
    }
}
