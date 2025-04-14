// Ignore Spelling: App

using System.Management;
using Microsoft.Win32;
using PC_Scan_App.Models.SoftwareModels;

namespace PC_Scan_App.Functions
{
    /*
        All the methods retrieve software information and store it into the models objects
        Initializing Management Object Searcher to query data
        Some of those are private helper methods
    */
    public class SoftwareDataFetcher
    {
        // Method to retrieve operating system information
        public static SystemModel GetOperatingSystemInfo()
        {
            var info = new SystemModel();

            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");

            var result = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            if (result != null)
            {
                info.Caption = result["Caption"]?.ToString();
                info.Version = result["Version"]?.ToString();
                info.BuildNumber = int.TryParse(result["BuildNumber"]?.ToString(), out int build) ? build : (int?)null;

                info.UpdateBuildRevision = GetRegistryValueAsInt(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "UBR");
                info.BuildBranch = GetRegistryValueAsString(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "BuildBranch");
                info.UpdateVersion = GetRegistryValueAsString(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "DisplayVersion");

                info.Manufacturer = result["Manufacturer"]?.ToString();
                info.OsArchitecture = result["OSArchitecture"]?.ToString();
                info.SerialNumber = result["SerialNumber"]?.ToString();

                info.InstallDate = ConvertToDateTime(result["InstallDate"]?.ToString());
                info.LastBootUpTime = ConvertToDateTime(result["LastBootUpTime"]?.ToString());

                info.FreePhysicalMemory = result["FreePhysicalMemory"]?.ToString();
                info.FreeVirtualMemory = result["FreeVirtualMemory"]?.ToString();
                info.TotalVirtualMemorySize = result["TotalVirtualMemorySize"]?.ToString();
                info.TotalVisibleMemorySize = result["TotalVisibleMemorySize"]?.ToString();
            }

            return info;
        }

        // Method to retrieve BIOS information
        public static BiosModel GetBIOSInfo()
        {
            var bios = new BiosModel();

            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_BIOS");

            var obj = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

            if (obj != null)
            {
                bios.BiosVersion = obj["Version"]?.ToString();
                bios.Manufacturer = obj["Manufacturer"]?.ToString();
                bios.ReleaseDate = ConvertToDateTime(obj["ReleaseDate"]?.ToString());
                bios.SerialNumber = obj["SerialNumber"]?.ToString();
            }

            return bios;
        }

        // Get registry value as integer
        private static int? GetRegistryValueAsInt(string path, string key)
        {
            var value = Registry.GetValue(path, key, null);
            return int.TryParse(value?.ToString(), out int result) ? result : (int?)null;
        }

        // Get registry value as string
        private static string? GetRegistryValueAsString(string path, string key)
        {
            return Registry.GetValue(path, key, null)?.ToString();
        }

        // Method to convert WMI date time to .NET date time
        private static string? ConvertToDateTime(string? wmiDate)
        {
            if (!string.IsNullOrWhiteSpace(wmiDate))
            {
                try
                {
                    return ManagementDateTimeConverter.ToDateTime(wmiDate).ToString();
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
    }
}
