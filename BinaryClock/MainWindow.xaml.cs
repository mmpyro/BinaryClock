using System;
using System.Windows;
using System.Windows.Input;

namespace BinaryClock
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Opacity = 0.5;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Locator.Close();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Opacity = 1.0;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Opacity = 0.5;
        }
    }
}
