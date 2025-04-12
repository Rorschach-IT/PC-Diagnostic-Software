using System.Windows;
using PC_Scan_App.ViewModels;

namespace PC_Scan_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext for the window to the MainViewModel
            this.DataContext = new MainViewModel();
        }

        public void showContent(object sender, RoutedEventArgs e)
        {
            InformationHeader.Visibility = Visibility.Visible;
            InformationDisplay.Visibility = Visibility.Visible;
        }
    }
}
