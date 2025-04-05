﻿using System;
using System.Linq;
using System.Management;
using Microsoft.Win32;

namespace Testing_Functionalities
{
    public class SystemModel
    {
        public string Caption { get; set; }
        public string Version { get; set; }
        public int? BuildNumber { get; set; }
        public int? UpdateBuildRevision { get; set; }
        public string BuildBranch { get; set; }
        public string UpdateVersion { get; set; }
        public string Manufacturer { get; set; }
        public string OsArchitecture { get; set; }
        public string SerialNumber { get; set; }
        public string InstallDate { get; set; }
        public string LastBootUpTime { get; set; }
        public string FreePhysicalMemory { get; set; }
        public string FreeVirtualMemory { get; set; }
        public string TotalVirtualMemorySize { get; set; }
        public string TotalVisibleMemorySize { get; set; }
    }

    internal class SoftwareDataFetcher
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

        private static string GetRegistryValueAsString(string path, string key)
        {
            return Registry.GetValue(path, key, null)?.ToString();
        }

        private static string ConvertToDateTime(string wmiDate)
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

    internal class Program
    {
        static void Main(string[] args)
        {
            SystemModel systemModel = SoftwareDataFetcher.GetOperatingSystemInfo();

            // Use reflection to iterate through all properties
            foreach (var prop in typeof(SystemModel).GetProperties())
            {
                var name = prop.Name;
                var value = prop.GetValue(systemModel) ?? "null";
                Console.WriteLine($"{name}: {value}");
            }

            Console.WriteLine("\n\n");
            Console.WriteLine(systemModel.BuildNumber);

        }
    }
}
