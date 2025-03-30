using System.Windows;
using System.Windows.Media;

namespace PC_Scan_App
{
    public partial class MainWindow : Window
    {
        private readonly Brush hoverBackground = (Brush)new BrushConverter().ConvertFromString("#EEDEDE");
        private readonly Brush defaultBackground = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
