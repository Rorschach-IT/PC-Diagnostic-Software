using System.Windows;
using PC_Scan_App.ViewModels;

namespace PC_Scan_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InformationHeader.Visibility = Visibility.Visible;
            InformationDisplay.Visibility = Visibility.Visible;
        }
    }
}
