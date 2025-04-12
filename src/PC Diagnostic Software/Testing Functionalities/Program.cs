using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Testing_Functionalities
{
    public class NetworkAdapterModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MACAddress { get; set; }
        public string AdapterType { get; set; }
        public bool? NetEnabled { get; set; }
        public string Manufacturer { get; set; }
        public string Speed { get; set; }
        public string IPAddress { get; set; }
        public string IPSubnet { get; set; }
        public string DefaultGateway { get; set; }
        public string DHCPServer { get; set; }
        public bool DHCPEnabled { get; set; }
    }


    public class HardwareDataFetcher
    {
        public static List<NetworkAdapterModel> GetNetworkAdapters()
        {
            var adapters = new List<NetworkAdapterModel>();

            try
            {
                // Run the 'ipconfig /all' command
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C ipconfig /all";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Split the output by lines and process each line
                var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                NetworkAdapterModel currentAdapter = null;

                foreach (var line in lines)
                {
                    // Detect the start of a new network adapter section
                    if (line.StartsWith("Ethernet adapter") || line.StartsWith("Wireless LAN adapter"))
                    {
                        if (currentAdapter != null)
                        {
                            adapters.Add(currentAdapter); // Add the previous adapter
                        }

                        currentAdapter = new NetworkAdapterModel
                        {
                            Name = line.Split(':')[0].Trim()
                        };
                    }

                    // Ensure that currentAdapter is not null before trying to assign values
                    if (currentAdapter != null)
                    {
                        // Parsing fields for IP configuration
                        if (line.Contains("Description"))
                        {
                            currentAdapter.Description = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("Physical")) // MAC address
                        {
                            currentAdapter.MACAddress = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("IP Address"))
                        {
                            currentAdapter.IPAddress = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("Subnet Mask"))
                        {
                            currentAdapter.IPSubnet = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("Default Gateway"))
                        {
                            currentAdapter.DefaultGateway = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("DHCP Server"))
                        {
                            currentAdapter.DHCPServer = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("DHCP Enabled"))
                        {
                            currentAdapter.DHCPEnabled = line.Split(':')[1].Trim() == "Yes";
                        }
                        else if (line.Contains("Adapter Type"))
                        {
                            currentAdapter.AdapterType = line.Split(':')[1].Trim();
                        }
                        else if (line.Contains("Speed"))
                        {
                            currentAdapter.Speed = line.Split(':')[1].Trim();
                        }
                    }
                }

                // Add the last adapter if it's not null
                if (currentAdapter != null)
                {
                    adapters.Add(currentAdapter);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching adapters: {ex.Message}");
            }

            return adapters;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                foreach (var module in HardwareDataFetcher.GetNetworkAdapters())
                {
                    foreach (var prop in typeof(NetworkAdapterModel).GetProperties())
                    {
                        var name = prop.Name;
                        var value = prop.GetValue(module) ?? "null";
                        Console.WriteLine($"{name}: {value}");

                    }
                }

                Console.WriteLine("Press any key to continue ...");
                Console.ReadLine();

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
}
