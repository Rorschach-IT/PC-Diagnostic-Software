// Ignore Spelling: App MVVM

using System.ComponentModel;

namespace PC_Scan_App.MVVM
{
    // Template for ViewModels (multiple references)
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
