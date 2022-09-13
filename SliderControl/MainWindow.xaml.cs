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

namespace SliderControl
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

        private void onTopSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (topTextBlock != null)
            {
                topTextBlock.Text = "Slider value is " + topSlider.Value.ToString();
                if (topSlider.Value > 0)
                {
                    topTextBlock.FontSize = topSlider.Value;
                }
            }
            
        }

        private void onBottomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
