// Ignore Spelling: App

namespace PC_Scan_App.Models.HardwareModels
{
    public class MemoryModel
    {
        public long? CapacityBytes { get; set; }
        public int? CapacityMB => CapacityBytes.HasValue ? (int)(CapacityBytes / 1024 / 1024) : null;
        public int? CapacityGB => CapacityMB.HasValue ? CapacityMB / 1024 : null;
        public int? Speed { get; set; }
        public string? Manufacturer { get; set; }
        public string? PartNumber { get; set; }
        public string? SerialNumber { get; set; }
        public int? FormFactor { get; set; }

        public static implicit operator MemoryModel(List<MemoryModel> v)
        {
            throw new NotImplementedException();
        }
    }

}
