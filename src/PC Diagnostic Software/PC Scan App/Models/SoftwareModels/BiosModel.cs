// Ignore Spelling: App

using PC_Scan_App.ViewModels.SoftwareViewModels;

namespace PC_Scan_App.Models.SoftwareModels
{
    public class BiosModel
    {
        public string? BiosVersion { get; set; }
        public string? Manufacturer { get; set; }
        public string? ReleaseDate { get; set; }
        public string? SerialNumber { get; set; }

        public static implicit operator BiosModel(BiosViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
