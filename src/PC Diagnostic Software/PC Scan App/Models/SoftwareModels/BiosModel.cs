﻿using PC_Scan_App.ViewModels.HardwareViewModels;

namespace PC_Scan_App.Models.HardwareModel
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
