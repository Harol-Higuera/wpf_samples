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

namespace CatAgeApp
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

        private void onKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                try
                {
                    int inputAge = Int32.Parse(inputCatAge.Text);
                    string humanAge = "";
                    if (inputAge > 0 && inputAge <= 1)
                    {
                        humanAge = "0-15";
                    }
                    else if (inputAge > 1 && inputAge <= 5)
                    {
                        humanAge = "0-15";
                    }
                    else if (inputAge > 5 && inputAge <= 10)
                    {
                        humanAge = "15-25";
                    }
                    else if (inputAge > 10 && inputAge <= 15)
                    {
                        humanAge = "25-45";
                    }
                    else if (inputAge > 15 && inputAge <= 20)
                    {
                        humanAge = "45-75";
                    }
                    else {
                        humanAge = "Way too many many";
                    }


                    resultTextBlock.Text = "Your cat is " + humanAge + " years old";



                }
                catch (Exception exeption) {
                    MessageBox.Show("Wrong Value.. Error:" + exeption);
                }
            }
        }
    }
}
