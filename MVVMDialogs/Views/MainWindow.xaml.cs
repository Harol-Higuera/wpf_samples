using MVVMDialogs.Dialogs;
using MVVMDialogs.ViewModels;
using System.Windows;

namespace MVVMDialogs.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Register this Dialog. Whenever we called the NotificationUserControlViewModel...
            //
            DialogService.RegisterDialog<NotificationUserControl, NotificationUserControlViewModel>();
        }
    }
}
