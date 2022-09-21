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

namespace MVVMDialogs.Dialogs
{
    /// <summary>
    /// Interaction logic for NotificationUserControl.xaml
    /// </summary>
    public partial class NotificationUserControl : UserControl
    {
        public NotificationUserControl()
        {
            InitializeComponent();
        }

        private void onCloseDialogClicked(object sender, RoutedEventArgs e)
        {
            /// A simple approach TO CLOSE THE DIALOG FROM A BUTTON EVENT
            /// 
            var window = this.Parent as Window;
            window.DialogResult = true;
        }
    }
}
