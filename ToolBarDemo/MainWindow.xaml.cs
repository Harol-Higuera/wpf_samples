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

namespace ToolBarDemo
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

        private void onDeleteClicked(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = "";
        }

        private void onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Required casting

            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            string newFontSize = (string)comboBoxItem.Content;

            // Required verification

            int temp;
            if (Int32.TryParse(newFontSize, out temp))
            {
                if (myTextBox != null) { 
                    myTextBox.FontSize = temp;
                }
            }
        }
    }
}
