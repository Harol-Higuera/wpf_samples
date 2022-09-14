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

namespace CatAgeAppProgramatically
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TextBlock resultTextBlock;
        public TextBox inputCatAge;

        public MainWindow()
        {
            InitializeComponent();

            // 1. Add th cat image
            // Link to solve image displaying. https://stackoverflow.com/a/25714375
            Image image = new Image() { 
                Source = new BitmapImage(
                     new Uri("pack://application:,,,/images/cat.jpg"))};

            // 2. Add the text Block
            resultTextBlock = new TextBlock() { 
                Text = "Your cat is",
                FontSize = 18
            };

            // 3. Add the text Box

            inputCatAge = new TextBox()
            {
                Width = 120,
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                Margin = new Thickness(5,0,0,0),
            };

            // 4. Add the key down listener to the TextBox

            inputCatAge.KeyDown += onKeyDownEvent;

            // 5. Add the itmes to the Screen

            TextBlock userQuestionTextBlock = new TextBlock() { 
                Text = "How old is your cat?",
                FontSize = 18,
            };

            StackPanel horizontalStackPanel = new StackPanel() { 
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(1,5,0,0),
            };
            horizontalStackPanel.Children.Add(userQuestionTextBlock);
            horizontalStackPanel.Children.Add(inputCatAge);

            StackPanel mainVerticalStackPanel = new StackPanel();
            mainVerticalStackPanel.Children.Add(horizontalStackPanel);
            mainVerticalStackPanel.Children.Add(resultTextBlock);
            mainVerticalStackPanel.Children.Add(image);
            myMainWindow.Content = mainVerticalStackPanel;

        }

        private void onKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
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
                    else
                    {
                        humanAge = "Way too many many";
                    }


                    resultTextBlock.Text = "Your cat is " + humanAge + " years old";



                }
                catch (Exception exeption)
                {
                    MessageBox.Show("Wrong Value.. Error:" + exeption);
                }
            }
        }
    }
}
