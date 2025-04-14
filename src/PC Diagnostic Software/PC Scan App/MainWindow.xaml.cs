using System.Windows;
using System.Windows.Controls;
using PC_Scan_App.ViewModels;

namespace PC_Scan_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext for the window to the MainViewModel
            DataContext = new MainViewModel();
        }

        private void ShowContent(object sender, RoutedEventArgs e)
        {
            InformationHeader.Visibility = Visibility.Visible;
            InformationDisplay.Visibility = Visibility.Visible;
            //Height = 800;
        }

        private void CopyValue_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem &&
                menuItem.Parent is ContextMenu contextMenu &&
                contextMenu.PlacementTarget is TextBox textBox)
            {
                Clipboard.SetText(textBox.Text);
            }
        }
    }
}
