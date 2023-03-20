using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CustomControls.Views
{
    public class AnalogClock: Control
    {

        private Line? _hourHand;
        private Line? _minuteHand;
        private Line? _secondHand;

        static AnalogClock()
        {
            // Apply Styling to AnalogClock
            // Defined in AnalogClockStyle.xaml
            //
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        public override void OnApplyTemplate()
        {
            _hourHand = Template.FindName("PART_HourHand", this) as Line;
            _minuteHand = Template.FindName("PART_MinuteHand", this) as Line;
            _secondHand = Template.FindName("PART_SecondHand", this) as Line;
            UpdateHandAngles();

            // Implement update the handles every single second
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += (sender, args) => UpdateHandAngles();
            timer.Start();
            
            base.OnApplyTemplate();
        }

        private void UpdateHandAngles()
        {
            // Rote the handles
            // Rotate along the center (0.5, 0.5)
            if (_hourHand != null) _hourHand.RenderTransform = new RotateTransform((DateTime.Now.Hour / 12.0) * 360, 0.5, 0.5);
            // 60 minutes in an hour
            if (_minuteHand != null) _minuteHand.RenderTransform = new RotateTransform((DateTime.Now.Minute / 60.0) * 360, 0.5, 0.5);
            // 60 seconds in a minute
            if (_secondHand != null) _secondHand.RenderTransform = new RotateTransform((DateTime.Now.Second / 60.0) * 360, 0.5, 0.5);
        }
    }
}
