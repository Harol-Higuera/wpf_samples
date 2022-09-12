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

namespace TextBlocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            topTextBlock.Foreground = Brushes.Orange;


            // Adding TextBlock Programatically

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Hello world";
            textBlock.Inlines.Add("This one is using inlines\n");
            textBlock.Inlines.Add(new Run("Custom formatted text inlined here.")
            {
                Foreground = Brushes.Orange,
                TextDecorations = TextDecorations.Underline
            });
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = Brushes.BurlyWood;

            this.Content = textBlock;
        }

        private void ToGoogle_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
