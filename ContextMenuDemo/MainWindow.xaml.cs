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

namespace ContextMenuDemo
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

        private void myItalicChecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontStyle = FontStyles.Italic;
        }

        private void myItalicUnChecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontStyle = FontStyles.Normal;
        }

        private void myBoldChecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontWeight = FontWeights.Bold;
        }

        private void myBoldUnChecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontWeight = FontWeights.Normal;
        }

        private void onChangeTextClicked(object sender, RoutedEventArgs e)
        {
            changeTextButton.Content = "Don't click me anymore!!";
        }
    }
}
