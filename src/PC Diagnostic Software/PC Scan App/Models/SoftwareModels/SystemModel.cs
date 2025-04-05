namespace PC_Scan_App.Models.HardwareModel
{
    public class SystemModel
    {
        public string? Caption { get; set; }
        public string? Version { get; set; }
        public int? BuildNumber { get; set; }
        public int? UpdateBuildRevision { get; set; }
        public string? BuildBranch { get; set; }
        public string? UpdateVersion { get; set; }
        public string? Manufacturer { get; set; }
        public string? OsArchitecture { get; set; }
        public string? SerialNumber { get; set; }
        public string? InstallDate { get; set; }
        public string? LastBootUpTime { get; set; }
        public string? FreePhysicalMemory { get; set; }
        public string? FreeVirtualMemory { get; set; }
        public string? TotalVirtualMemorySize { get; set; }
        public string? TotalVisibleMemorySize { get; set; }
    }
}
