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

namespace CustomControlsResizable.Views
{
    /// <summary>
    /// Interaction logic for ControllableClock.xaml
    /// </summary>
    public partial class ControllableClock : UserControl
    {
        /// <summary>
        /// Dependency property to set the Type Of clock in the XAML file
        /// </summary>
        public static readonly DependencyProperty ClockProperty = DependencyProperty.Register(
            nameof(Clock), typeof(Clock), typeof(ControllableClock), new PropertyMetadata(null));
        public Clock Clock
        {
            get => (Clock)GetValue(ClockProperty);
            set => SetValue(ClockProperty, value);
        }
        public ControllableClock()
        {
            InitializeComponent();
        }
    }
}
