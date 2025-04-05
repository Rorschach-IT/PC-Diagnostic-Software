using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Testing_Functionalities
{
    public class StorageModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string MediaType { get; set; }
        public string SerialNumber { get; set; }
        public long? SizeBytes { get; set; }

        public double? SizeKB => SizeBytes.HasValue ? SizeBytes / 1024.0 : null;
        public double? SizeMB => SizeKB.HasValue ? SizeKB / 1024.0 : null;
        public double? SizeGB => SizeMB.HasValue ? SizeMB / 1024.0 : null;
        public double? SizeTB => SizeGB.HasValue ? SizeGB / 1024.0 : null;
    }

    public class HardwareDataFetcher
    {
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                STORAGE: 
            */
            //foreach (var module in HardwareDataFetcher.GetStorageInfo()) // lista StorageModel
            //{
            //    foreach (var prop in typeof(StorageModel).GetProperties())
            //    {
            //        var name = prop.Name;
            //        var value = prop.GetValue(module) ?? "null";
            //        Console.WriteLine($"{name}: {value}");
            //    }

            //    Console.WriteLine(new string('-', 30)); // Separator between drives
            //}

            /*
                OS MEMORY:
            */
            //foreach (var module in memoryModules)
            //{
            //    foreach (var prop in typeof(MemoryModel).GetProperties())
            //    {
            //        var name = prop.Name;
            //        var value = prop.GetValue(module) ?? "null";
            //        Console.WriteLine($"{name}: {value}");
            //    }

            //    Console.WriteLine(new string('-', 30)); // Separator between modules
            //}

            /*
                REST: 
            */
            //ProcessorModel processorModel = HardwareDataFetcher.GetProcessorInfo();

            //foreach (var prop in typeof(ProcessorModel).GetProperties())
            //{
            //    var name = prop.Name;
            //    var value = prop.GetValue(processorModel) ?? "null";
            //    Console.WriteLine($"{name}: {value}");
            //}


            //Console.WriteLine("\n" + processorModel.ProcessorId);
        }
    }
}
