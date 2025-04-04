namespace PC_Scan_App.Models.SoftwareModel
{
    public class Processor
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public int? NumberOfCores { get; set; }
        public int? NumberOfLogicalProcessors { get; set; }
        public string? ProcessorId { get; set; }
        public int? Architecture { get; set; }
    }
}
