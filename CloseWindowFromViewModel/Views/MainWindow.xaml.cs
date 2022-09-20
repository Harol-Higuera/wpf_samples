using CloseWindowFromViewModel.ViewModels;
using System;
using System.Windows;

namespace CloseWindowFromViewModel.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext implements ICloseWindow 
            // 

            if (DataContext is ICloseWindow vm) {
                
                // And when the Close Action is invoked.. WE DO SOMETHING HERE
                //
                vm.Close += () =>
                {
                    this.Close();
                };

                // Listen to the Closing event of this Vindow
                // Then, cancel the closing if the canClose is false in the View Model
                // 
                Closing += (s, e) =>
                {
                    e.Cancel = !vm.canClose();
                };
            }
        }
    }
}
