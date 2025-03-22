﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Background = hoverBackground;
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Background = defaultBackground;
            }
        }
    }
}
