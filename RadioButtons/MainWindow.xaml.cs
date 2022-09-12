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

namespace RadioButtons
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
            uncheckAll();
            optionObama.Background = Brushes.LightCoral;
        }

        private void onTrumpChecked(object sender, RoutedEventArgs e)
        {
            uncheckAll();
            optionTrump.Background = Brushes.LightCoral;
        }

        private void onMcCainChecked(object sender, RoutedEventArgs e)
        {
            uncheckAll();
            optionMcCain.Background = Brushes.LightCoral;
        }

        private void onBidenChecked(object sender, RoutedEventArgs e)
        {
            uncheckAll();
            optionBiden.Background = Brushes.LightCoral;
        }

        private void uncheckAll() {
            optionBiden.Background = Brushes.White;
            optionMcCain.Background = Brushes.White;
            optionTrump.Background = Brushes.White;
            optionObama.Background = Brushes.White;
        }
    }
}
