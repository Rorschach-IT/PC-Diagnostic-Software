namespace PC_Scan_App.Models.HardwareModels
{
    public class GraphicsCardModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public string? DriverVersion { get; set; }
        public string? VideoProcessor { get; set; }
        public ulong? AdapterRAM { get; set; }
        public string? VideoModeDescription { get; set; }
        public int? CurrentRefreshRate { get; set; }
        public int? HorizontalResolution { get; set; }
        public int? VerticalResolution { get; set; }
        public string? InstalledDisplayDrivers { get; set; }
        public string? Status { get; set; }
    }
}
