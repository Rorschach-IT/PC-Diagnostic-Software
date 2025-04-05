namespace PC_Scan_App.Models.SoftwareModel
{
    public class Storage
    {
        public string? Id { get; set; }
        public string? Model { get; set; }
        public string? InterfaceType { get; set; }
        public string? MediaType { get; set; }
        public string? SerialNumber { get; set; }
        public long? SizeBytes { get; set; }
        public double? SizeKB => SizeBytes.HasValue ? SizeBytes / 1024.0 : null;
        public double? SizeMB => SizeKB.HasValue ? SizeKB / 1024.0 : null;
        public double? SizeGB => SizeMB.HasValue ? SizeMB / 1024.0 : null;
        public double? SizeTB => SizeGB.HasValue ? SizeGB / 1024.0 : null;
    }

}
