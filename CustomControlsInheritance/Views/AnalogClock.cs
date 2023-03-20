using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomControlsInheritance.Views
{
    public class AnalogClock: Clock
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

            // Tide up ShowSecondsProperty to the second hand
            // METHOD: By User a Binding
            // NOTE: This demo uses Template Binding instead. (Implemented in AnalogClockStyle.xaml)
            //
            //Binding showSecondHandBinding = new Binding
            //{
            //    Path = new PropertyPath(nameof(ShowSeconds)),
            //    Source = this,
            //    Converter = new BooleanToVisibilityConverter()
            //};
            //_secondHand?.SetBinding(VisibilityProperty, showSecondHandBinding);

            base.OnApplyTemplate();
        }

        // virtual. Makes it overridable
        protected override void OnTimeChanged(DateTime time)
        {
            // 1:::: Update the UI
            UpdateHandAngles(time);
            base.OnTimeChanged(time);
        }

        private void UpdateHandAngles(DateTime time)
        {
            // Rote the handles
            // Rotate along the center (0.5, 0.5)
            if (_hourHand != null) _hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5);
            // 60 minutes in an hour
            if (_minuteHand != null) _minuteHand.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5);
            // 60 seconds in a minute
            if (_secondHand != null) _secondHand.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5);
        }
    }
}
