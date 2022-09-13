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

namespace CheckBoxes
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

        private void onObamaChecked(object sender, RoutedEventArgs e)
        {
            obamaLabel.Background = Brushes.Khaki;
        }

        private void onObamaUnchecked(object sender, RoutedEventArgs e)
        {
            obamaLabel.Background = Brushes.White;

        }

        private void cbParentChecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
