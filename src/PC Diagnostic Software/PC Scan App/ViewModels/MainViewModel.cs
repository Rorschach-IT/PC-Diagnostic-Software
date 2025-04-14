// Ignore Spelling: App

using System.Collections.ObjectModel;
using System.Windows.Input;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Data collections
        public ObservableCollection<KeyValuePair<string, string>> Processor { get; }
        public ObservableCollection<KeyValuePair<string, string>> Motherboard { get; }
        public ObservableCollection<KeyValuePair<string, string>> Memory { get; }
        public ObservableCollection<KeyValuePair<string, string>> Storage { get; }
        public ObservableCollection<KeyValuePair<string, string>> GraphicsCards { get; }
        public ObservableCollection<KeyValuePair<string, string>> System { get; }
        public ObservableCollection<KeyValuePair<string, string>> Bios { get; }

        // Current data collection that is bound to the ListView in XAML
        private ObservableCollection<KeyValuePair<string, string>> _currentData = [];
        public ObservableCollection<KeyValuePair<string, string>> CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; OnPropertyChanged(nameof(CurrentData)); }
        }

        // Interface commands
        public ICommand ShowWindowsInfo { get; }
        public ICommand ShowBiosInfo { get; }
        public ICommand ShowProcessorInfo { get; }
        public ICommand ShowMotherboardInfo { get; }
        public ICommand ShowMemoryInfo { get; }
        public ICommand ShowStorageInfo { get; }
        public ICommand ShowGraphicsCardInfo { get; }

        public MainViewModel()
        {
            Processor = [];
            Motherboard = [];
            Memory = [];
            Storage = [];
            GraphicsCards = [];
            System = [];
            Bios = [];

            // Initialize CurrentData to avoid null reference
            CurrentData = [];

            ShowProcessorInfo = new RelayCommand(_ => LoadProcessorData());
            ShowMotherboardInfo = new RelayCommand(_ => LoadMotherboardData());
            ShowMemoryInfo = new RelayCommand(_ => LoadMemoryData());
            ShowStorageInfo = new RelayCommand(_ => LoadStorageData());
            ShowGraphicsCardInfo = new RelayCommand(_ => LoadGraphicsCardData());
            ShowWindowsInfo = new RelayCommand(_ => LoadSystemData());
            ShowBiosInfo = new RelayCommand(_ => LoadBiosData());
        }

        /*
            Those methods are used to load and bind data to the CurrentData property
            They are called from the interface commands
            At the end of every method, build in Clear() method is called in order to avoid duplicates
        */

        // Method to load and bind the correct data to the CurrentData property
        private void LoadAndBindData(ObservableCollection<KeyValuePair<string, string>> data)
        {
            CurrentData.Clear();

            foreach (var item in data)
            {
                CurrentData.Add(item);  // Add new data
            }
            OnPropertyChanged(nameof(CurrentData));  // Notify UI to update
        }

        private string? _sectionHeader;
        public string SectionHeader
        {
            get { return _sectionHeader!; }
            set { _sectionHeader = value; OnPropertyChanged(nameof(SectionHeader)); }
        }

        // Method to load Windows system info (OS info)
        public void LoadSystemData()
        {
            SectionHeader = "Windows Full Information:";

            if (System.Count > 0) return;

            var systemInfo = Functions.SoftwareDataFetcher.GetOperatingSystemInfo();

            System.Add(new KeyValuePair<string, string>("OS Name:", systemInfo.Caption!));
            System.Add(new KeyValuePair<string, string>("Version:", systemInfo.Version!));
            System.Add(new KeyValuePair<string, string>("Build Number:", systemInfo.BuildNumber?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Last Boot Time:", systemInfo.LastBootUpTime?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Update Version:", systemInfo.UpdateVersion ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Update Build Revision:", systemInfo.UpdateBuildRevision?.ToString() ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Manufacturer:", systemInfo.Manufacturer ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("OS Architecture:", systemInfo.OsArchitecture ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Serial Number:", systemInfo.SerialNumber ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Install Date:", systemInfo.InstallDate ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Free Physical Memory:", systemInfo.FreePhysicalMemory ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Free Virtual Memory:", systemInfo.FreeVirtualMemory ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Total Virtual Memory Size:", systemInfo.TotalVirtualMemorySize ?? "N/A"));
            System.Add(new KeyValuePair<string, string>("Total Visible Memory Size:", systemInfo.TotalVisibleMemorySize ?? "N/A"));

            LoadAndBindData(System);

            System.Clear();
        }

        // Method to load BIOS data
        public void LoadBiosData()
        {
            SectionHeader = "BIOS data:";

            if (Bios.Count > 0) return;

            var biosInfo = Functions.SoftwareDataFetcher.GetBIOSInfo();

            Bios.Add(new KeyValuePair<string, string>("Manufacturer:", biosInfo.Manufacturer ?? "N/A"));
            Bios.Add(new KeyValuePair<string, string>("Version:", biosInfo.BiosVersion ?? "N/A"));
            Bios.Add(new KeyValuePair<string, string>("Release Date:", biosInfo.ReleaseDate ?? "N/A"));
            Bios.Add(new KeyValuePair<string, string>("Serial Number:", biosInfo.SerialNumber ?? "N/A"));

            LoadAndBindData(Bios);

            Bios.Clear();
        }

        // Method to load processor data
        public void LoadProcessorData()
        {
            SectionHeader = "Processor:";

            if (Processor.Count > 0) return;

            var cpu = Functions.HardwareDataFetcher.GetProcessorInfo();

            Processor.Add(new KeyValuePair<string, string>("Name:", cpu.Name ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Manufacturer:", cpu.Manufacturer ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Description:", cpu.Description ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Cores:", cpu.NumberOfCores?.ToString() ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Logical Processors:", cpu.NumberOfLogicalProcessors?.ToString() ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Processor ID:", cpu.ProcessorId ?? "N/A"));
            Processor.Add(new KeyValuePair<string, string>("Architecture:", cpu.Architecture?.ToString() ?? "N/A"));

            LoadAndBindData(Processor);

            Processor.Clear();
        }

        // Method to load motherboard data
        public void LoadMotherboardData()
        {
            SectionHeader = "Motherboard:";

            if (Motherboard.Count > 0) return;

            var mb = Functions.HardwareDataFetcher.GetMotherboardInfo();

            Motherboard.Add(new KeyValuePair<string, string>("Product:", mb.Product ?? "N/A"));
            Motherboard.Add(new KeyValuePair<string, string>("Manufacturer:", mb.Manufacturer ?? "N/A"));
            Motherboard.Add(new KeyValuePair<string, string>("Serial Number:", mb.SerialNumber ?? "N/A"));
            Motherboard.Add(new KeyValuePair<string, string>("Version:", mb.Version ?? "N/A"));

            LoadAndBindData(Motherboard);

            Motherboard.Clear();
        }

        // Method to load memory data
        public void LoadMemoryData()
        {
            SectionHeader = "Memory:";

            if (Memory.Count > 0) return;

            var modules = Functions.HardwareDataFetcher.GetMemoryInfo();

            for (int i = 0; i < modules.Count; i++)
            {
                // Add a separator (if there is more than one module)
                if (i > 0)
                {
                    Memory.Add(new KeyValuePair<string, string>("", ""));
                }

                var mem = modules[i];

                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Capacity (GB):", mem.CapacityGB?.ToString() ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Capacity (MB):", mem.CapacityMB?.ToString() ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Capacity (Bytes):", mem.CapacityBytes?.ToString() ?? "N/A"));

                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Speed:", mem.Speed?.ToString() ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Manufacturer:", mem.Manufacturer ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Part Number:", mem.PartNumber ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Serial Number:", mem.SerialNumber ?? "N/A"));
                Memory.Add(new KeyValuePair<string, string>($"Module {i + 1} - Form Factor:", mem.FormFactor?.ToString() ?? "N/A"));
            }

            LoadAndBindData(Memory);

            Memory.Clear();
        }

        // Method to load storage data
        public void LoadStorageData()
        {
            SectionHeader = "Storage:";

            if (Storage.Count > 0) return;

            var drives = Functions.HardwareDataFetcher.GetStorageInfo();

            for (int i = 0; i < drives.Count; i++)
            {
                var disk = drives[i];

                // Add a separator (if there is more than one drive)
                if (i > 0)
                {
                    Storage.Add(new KeyValuePair<string, string>("", ""));
                }

                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Size (TB):", disk.SizeTB?.ToString("0.##") ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Size (GB):", disk.SizeGB?.ToString("0.##") ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Size (MB):", disk.SizeMB?.ToString("0.##") ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Size (KB):", disk.SizeKB?.ToString("0.##") ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Size (Bytes):", disk.SizeBytes?.ToString() ?? "N/A"));

                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Model:", disk.Model ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - ID:", disk.Id ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Interface:", disk.InterfaceType ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Media Type:", disk.MediaType ?? "N/A"));
                Storage.Add(new KeyValuePair<string, string>($"Drive {i + 1} - Serial Number:", disk.SerialNumber ?? "N/A"));
            }

            LoadAndBindData(Storage);

            Storage.Clear();
        }

        // Method to load graphics card data
        public void LoadGraphicsCardData()
        {
            SectionHeader = "Graphics Card:";

            if (GraphicsCards.Count > 0) return;

            var graphicsCards = Functions.HardwareDataFetcher.GetGraphicsCardInfo();

            for (int i = 0; i < graphicsCards.Count; i++)
            {
                var gpu = graphicsCards[i];

                // Add a separator (if there is more than one GPU)
                if (i > 0)
                {
                    GraphicsCards.Add(new KeyValuePair<string, string>("", ""));
                }

                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Name:", gpu.Name ?? "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Manufacturer:", gpu.Manufacturer ?? "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Description:", gpu.Description ?? "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Driver Version:", gpu.DriverVersion ?? "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Video Processor:", gpu.VideoProcessor ?? "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Adapter RAM (MB):", gpu.AdapterRAM.HasValue ? (gpu.AdapterRAM.Value / (1024 * 1024)).ToString() : "N/A"));
                GraphicsCards.Add(new KeyValuePair<string, string>($"GPU {i + 1} - Status:", gpu.Status ?? "N/A"));
            }

            LoadAndBindData(GraphicsCards);

            GraphicsCards.Clear();
        }
    }
}
