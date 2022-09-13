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

namespace ImageControl
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

        private void onTopImageMouseUp(object sender, MouseButtonEventArgs e)
        {
            // TODO(Anyone): This isn't working. Understand how this really works.
            topImage.Source = new BitmapImage(
                new Uri("/images/doraemon.jpg", UriKind.Relative));
        }
    }
}
