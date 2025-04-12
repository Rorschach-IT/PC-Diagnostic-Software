using System.Collections.ObjectModel;
using PC_Scan_App.MVVM;
using PC_Scan_App.ViewModels.HardwareViewModels;

namespace PC_Scan_App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public SystemViewModel SystemViewModel { get; }
        //public BiosViewModel BiosViewModel { get; }
        //public MotherboardViewModel MotherboardViewModel { get; }
        //public ProcessorViewModel ProcessorViewModel { get; }
        //public MemoryViewModel MemoryViewModel { get; }
        //public StorageViewModel StorageViewModel { get; }
        //public GraphicsCardViewModel GraphicsCardViewModel { get; }

        public ObservableCollection<KeyValuePair<string, string>> Information => SystemViewModel.System;

        public MainViewModel()
        {
            SystemViewModel = new SystemViewModel();
            //BiosViewModel = new BiosViewModel();
            //ProcessorViewModel = new ProcessorViewModel();
            //MotherboardViewModel = new MotherboardViewModel();
            //MemoryViewModel = new MemoryViewModel();
            //StorageViewModel = new StorageViewModel();
            //GraphicsCardViewModel = new GraphicsCardViewModel();
        }
    }
}
