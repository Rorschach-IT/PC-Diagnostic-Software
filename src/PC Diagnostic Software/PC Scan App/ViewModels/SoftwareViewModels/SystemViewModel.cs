using System.ComponentModel;
using PC_Scan_App.Models.HardwareModel;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class SystemViewModel : INotifyPropertyChanged
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

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void LoadSystemData()
        {
            SystemModel = Functions.SoftwareDataFetcher.GetOperatingSystemInfo();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
