using PC_Scan_App.Models.SoftwareModel;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.SoftwareViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        private List<StorageModel> _storage;
        public List<StorageModel> StorageModel
        {
            get => _storage;
            set
            {
                _storage = value;
                OnPropertyChanged(nameof(StorageModel));
            }
        }
        public StorageViewModel()
        {
            _storage = [];
        }

        public void LoadStorageData()
        {
            StorageModel = Functions.HardwareDataFetcher.GetStorageInfo();
        }
    }
}
