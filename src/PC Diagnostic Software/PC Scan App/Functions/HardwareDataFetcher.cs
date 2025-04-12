using System.Management;
using PC_Scan_App.Models.HardwareModels;
using PC_Scan_App.Models.SoftwareModel;

namespace PC_Scan_App.Functions
{
    public class HardwareDataFetcher
    {
        // Method to retrieve processor information
        public static ProcessorModel GetProcessorInfo()
        {
            var processor = new ProcessorModel();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            var result = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            if (result != null)
            {
                processor.Name = result["Name"]?.ToString();
                processor.Manufacturer = result["Manufacturer"]?.ToString();
                processor.Description = result["Description"]?.ToString();
                processor.NumberOfCores = int.TryParse(result["NumberOfCores"]?.ToString(), out int cores) ? cores : (int?)null;
                processor.NumberOfLogicalProcessors = int.TryParse(result["NumberOfLogicalProcessors"]?.ToString(), out int logical) ? logical : (int?)null;
                processor.ProcessorId = result["ProcessorId"]?.ToString();
                processor.Architecture = int.TryParse(result["Architecture"]?.ToString(), out int arch) ? arch : (int?)null;
            }

            return processor;
        }

        // Method to retrieve motherboard information
        public static MotherboardModel GetMotherboardInfo()
        {
            var motherboard = new MotherboardModel();

            // Initialize a ManagementObjectSearcher to query Win32_BaseBoard
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            var result = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            if (result != null)
            {
                motherboard.Product = result["Product"]?.ToString();
                motherboard.Manufacturer = result["Manufacturer"]?.ToString();
                motherboard.SerialNumber = result["SerialNumber"]?.ToString();
                motherboard.Version = result["Version"]?.ToString();
            }

            return motherboard;
        }

        /*
            LIST functions 
        */
        // Method to retrieve memory information
        public static List<MemoryModel> GetMemoryInfo()
        {
            var memoryList = new List<MemoryModel>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            foreach (ManagementObject obj in searcher.Get().OfType<ManagementObject>())
            {
                var memory = new MemoryModel
                {
                    CapacityBytes = obj["Capacity"] != null ? (long?)Convert.ToUInt64(obj["Capacity"]) : null,
                    Speed = obj["Speed"] != null ? (int?)Convert.ToInt32(obj["Speed"]) : null,
                    Manufacturer = obj["Manufacturer"]?.ToString(),
                    PartNumber = obj["PartNumber"]?.ToString(),
                    SerialNumber = obj["SerialNumber"]?.ToString(),
                    FormFactor = obj["FormFactor"] != null ? (int?)Convert.ToInt32(obj["FormFactor"]) : null
                };

                memoryList.Add(memory);
            }

            return memoryList;
        }

        // Method to retrieve storage information
        public static List<StorageModel> GetStorageInfo()
        {
            var storageList = new List<StorageModel>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                var storage = new StorageModel
                {
                    Id = obj["DeviceID"]?.ToString(),
                    Model = obj["Model"]?.ToString(),
                    InterfaceType = obj["InterfaceType"]?.ToString(),
                    MediaType = obj["MediaType"]?.ToString(),
                    SerialNumber = obj["SerialNumber"]?.ToString(),
                    SizeBytes = long.TryParse(obj["Size"]?.ToString(), out long size) ? size : (long?)null
                };

                storageList.Add(storage);
            }

            return storageList;
        }

        public static List<GraphicsCardModel> GetGraphicsCardInfo()
        {
            var graphicsCards = new List<GraphicsCardModel>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                var gpu = new GraphicsCardModel
                {
                    Name = obj["Name"]?.ToString(),
                    Description = obj["Description"]?.ToString(),
                    Manufacturer = obj["AdapterCompatibility"]?.ToString(),
                    DriverVersion = obj["DriverVersion"]?.ToString(),
                    VideoProcessor = obj["VideoProcessor"]?.ToString(),
                    AdapterRAM = ulong.TryParse(obj["AdapterRAM"]?.ToString(), out var ram) ? ram : null,
                    VideoModeDescription = obj["VideoModeDescription"]?.ToString(),
                    CurrentRefreshRate = int.TryParse(obj["CurrentRefreshRate"]?.ToString(), out var refresh) ? refresh : null,
                    HorizontalResolution = int.TryParse(obj["CurrentHorizontalResolution"]?.ToString(), out var hRes) ? hRes : null,
                    VerticalResolution = int.TryParse(obj["CurrentVerticalResolution"]?.ToString(), out var vRes) ? vRes : null,
                    InstalledDisplayDrivers = obj["InstalledDisplayDrivers"]?.ToString(),
                    Status = obj["Status"]?.ToString()
                };

                graphicsCards.Add(gpu);
            }

            return graphicsCards;
        }
    }
}
