using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buttons
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

        private void onButtonClicked(object sender, RoutedEventArgs e)
        {
            myLabel.Foreground = Brushes.Coral;
            myLabel.FontSize = myLabel.FontSize + 1;
        }

        private void onMouseDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            myLabel.Foreground = Brushes.Blue;
            myLabel.FontSize = myLabel.FontSize - 1;
        }

        private void onMouseLeave(object sender, MouseEventArgs e)
        {
            myButton.Background = Brushes.Black;
            myButton.Foreground = Brushes.White;
        }
    }
}
