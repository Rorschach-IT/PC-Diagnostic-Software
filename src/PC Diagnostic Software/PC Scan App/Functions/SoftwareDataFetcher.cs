using System.Management;
using Microsoft.Win32;
using PC_Scan_App.Models.HardwareModel;

namespace PC_Scan_App.Functions
{
    public class SoftwareDataFetcher
    {
        public static SystemModel GetOperatingSystemInfo()
        {
            var info = new SystemModel();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
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

        private static int? GetRegistryValueAsInt(string path, string key)
        {
            var value = Registry.GetValue(path, key, null);
            return int.TryParse(value?.ToString(), out int result) ? result : (int?)null;
        }

        private static string? GetRegistryValueAsString(string path, string key)
        {
            return Registry.GetValue(path, key, null)?.ToString();
        }

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
