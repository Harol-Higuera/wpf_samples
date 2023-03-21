using System;
using System.Windows;

namespace CustomControlsResizable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalogClock_OnTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime> e)
        {
            //TbTime.Text = e.NewValue.ToString("hh:mm:ss");
        }
    }
}
