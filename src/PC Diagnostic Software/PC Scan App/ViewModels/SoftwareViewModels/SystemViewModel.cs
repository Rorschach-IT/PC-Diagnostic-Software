using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class SystemViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _system;
        public ObservableCollection<KeyValuePair<string, string>> System
        {
            get => _system;
            set
            {
                _system = value;
                OnPropertyChanged(nameof(System));
            }
        }

        public ICommand ShowWindowsInfo { get; }

        public SystemViewModel()
        {
            _system = new ObservableCollection<KeyValuePair<string, string>>();
            ShowWindowsInfo = new RelayCommand(_ => LoadSystemData());
        }

        public void LoadSystemData()
        {
            System.Clear();

            var systemInfo = Functions.SoftwareDataFetcher.GetOperatingSystemInfo();
            System.Add(new KeyValuePair<string, string>("OS Name:", systemInfo.Caption));
            System.Add(new KeyValuePair<string, string>("Version", systemInfo.Version));
            System.Add(new KeyValuePair<string, string>("Build Number", systemInfo.BuildNumber?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Last Boot Time", systemInfo.LastBootUpTime?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Update Version", systemInfo.UpdateVersion ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Update Build Revision", systemInfo.UpdateBuildRevision?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Manufacturer", systemInfo.Manufacturer ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("OS Architecture", systemInfo.OsArchitecture ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Serial Number", systemInfo.SerialNumber ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Install Date", systemInfo.InstallDate ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Free Physical Memory", systemInfo.FreePhysicalMemory ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Free Virtual Memory", systemInfo.FreeVirtualMemory ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Total Virtual Memory Size", systemInfo.TotalVirtualMemorySize ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Total Visible Memory Size", systemInfo.TotalVisibleMemorySize ?? "N/A"));
        }
    }
}
