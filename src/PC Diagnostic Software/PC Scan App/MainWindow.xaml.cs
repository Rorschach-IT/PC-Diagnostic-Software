// Ignore Spelling: App

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        // Method to show content
        private void ShowContent(object sender, RoutedEventArgs e)
        {
            InformationHeader.Visibility = Visibility.Visible;
            InformationDisplay.Visibility = Visibility.Visible;
        }

        // Method to copy value from text box (only copy)
        private void CopyValue_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem &&
                menuItem.Parent is ContextMenu contextMenu &&
                contextMenu.PlacementTarget is TextBox textBox)
            {
                Clipboard.SetText(textBox.Text);
            }
        }

        // Method to scroll the list (no default WPF scroll)
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer? scrollViewer = sender as ScrollViewer;

            if (scrollViewer != null)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
                e.Handled = true;
            }
        }
    }
}
