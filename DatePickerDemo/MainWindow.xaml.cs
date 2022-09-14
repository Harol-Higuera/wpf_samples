﻿using System;
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

namespace DatePickerDemo
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

        private void onDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not null) {
                if ((sender as DatePicker)?.SelectedDate != null) {
                    string? myDate = (sender as DatePicker)?.SelectedDate.ToString();
                    MessageBox.Show("The date has changed to:" + myDate);
                }
            }   
        }
    }
}
