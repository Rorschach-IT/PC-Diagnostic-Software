namespace PC_Scan_App.Models.SoftwareModel
{
    public class Memory
    {
        public long? CapacityBytes { get; set; }
        public int? CapacityMB => CapacityBytes.HasValue ? (int)(CapacityBytes / 1024 / 1024) : null;
        public int? CapacityGB => CapacityMB.HasValue ? CapacityMB / 1024 : null;
        public int? Speed { get; set; }
        public string? Manufacturer { get; set; }
        public string? PartNumber { get; set; }
        public string? SerialNumber { get; set; }
        public int? FormFactor { get; set; }
    }

}
