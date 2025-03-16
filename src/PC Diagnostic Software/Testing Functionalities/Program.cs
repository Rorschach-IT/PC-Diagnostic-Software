using System;
using System.Linq;
using System.Management;

namespace Testing_Functionalities
{
    internal class Program
    {
        public static void GetOperatingSystemInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                Console.WriteLine($"Caption: {obj["Caption"]}");
                Console.WriteLine($"Version: {obj["Version"]}");
                Console.WriteLine($"Build Number: {obj["BuildNumber"]}");

                // Retrieve Update Build Revision (UBR) if available
                var ubr = GetRegistryValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "UBR");
                if (ubr != null)
                {
                    Console.WriteLine($"Update Build Revision: {ubr}");
                }

                // Retrieve Build Branch if available
                var buildBranch = GetRegistryValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "BuildBranch");
                if (buildBranch != null)
                {
                    Console.WriteLine($"Build Branch: {buildBranch}");
                }

                // Retrieve Windows Update Version if available
                var displayVersion = GetRegistryValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "DisplayVersion");
                if (displayVersion != null)
                {
                    Console.WriteLine($"Update Version: {displayVersion}");
                }

                Console.WriteLine($"Manufacturer: {obj["Manufacturer"]}");
                Console.WriteLine($"OS Architecture: {obj["OSArchitecture"]}");
                Console.WriteLine($"Serial Number: {obj["SerialNumber"]}");
                Console.WriteLine($"Install Date: {ManagementDateTimeConverter.ToDateTime(obj["InstallDate"].ToString())}");
                Console.WriteLine($"Last Boot Up Time: {ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString())}");

                // Converting [KB] to [GB]
                UInt64 FreePhysicalMemoryGB = (ulong)obj["FreePhysicalMemory"] / (1024 * 1024);
                UInt64 FreeVirtualMemoryGB = (ulong)obj["FreeVirtualMemory"] / (1024 * 1024);
                UInt64 TotalVirtualMemoryGB = (ulong)obj["TotalVirtualMemorySize"] / (1024 * 1024);
                UInt64 TotalVisibleMemoryGB = (ulong)obj["TotalVisibleMemorySize"] / (1024 * 1024);

                Console.WriteLine($"Free Physical Memory: {obj["FreePhysicalMemory"]} [KB] - {FreePhysicalMemoryGB} [GB]");
                Console.WriteLine($"Free Virtual Memory: {obj["FreeVirtualMemory"]} [KB] - {FreeVirtualMemoryGB} [GB]");
                Console.WriteLine($"Total Virtual Memory Size: {obj["TotalVirtualMemorySize"]} [KB] - {TotalVirtualMemoryGB} [GB]");
                Console.WriteLine($"Total Visible Memory Size: {obj["TotalVisibleMemorySize"]} [KB] - {TotalVisibleMemoryGB} [GB]");

                Console.WriteLine();
            }
        }

        private static object GetRegistryValue(string path, string key)
        {
            try
            {
                return Microsoft.Win32.Registry.GetValue(path, key, null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve registry value: {e.Message}");
                return null;
            }
        }
        public static void GetMotherboardInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                Console.WriteLine($"Product: {obj["Product"]}");
                Console.WriteLine($"Manufacturer: {obj["Manufacturer"]}");
                Console.WriteLine($"Serial Number: {obj["SerialNumber"]}");
                Console.WriteLine($"Version: {obj["Version"]}");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nSystem:");
            GetOperatingSystemInfo();

            Console.WriteLine("\nMemory:");
            GetMotherboardInfo();
        }
    }
}
