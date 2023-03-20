using System;
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

        /// <summary>
        /// Property to alter the UI from the cs View Class
        /// Concepts:
        ///  - DependencyProperty: Is a property for XAML controllers. Allow us to access the xaml components for styling, validation etc..
        /// </summary>
        public static DependencyProperty ShowSecondsProperty = DependencyProperty.Register(nameof(ShowSeconds), typeof(bool),typeof(AnalogClock), new PropertyMetadata(true));
        // Property in the Analog Clock that hooks up with the ShowSecondsProperty
        public bool ShowSeconds
        {
            get => (bool)GetValue(ShowSecondsProperty);
            set => SetValue(ShowSecondsProperty, value);
        }



        /// <summary>
        /// Property to send messages to the parent View
        /// Concepts:
        ///  - Why to use RoutedEvent?
        ///    - Because it can be used in all the WPF Xaml Tree.Not only the element that defines it, but all the elements in the tree
        ///  - RouterEvent gets passed through the Delegate as parameter
        ///  - RoutingStrategy.Direct : Only the AnalogClock can change the events
        /// </summary>
        public static RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(AnalogClock));
        public event RoutedPropertyChangedEventHandler<DateTime> TimeChanged
        {
            add => AddHandler(TimeChangedEvent, value);
            remove => RemoveHandler(TimeChangedEvent, value);
        }

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

            UpdateHandAngles(DateTime.Now);

            // Implement update the handles every single second
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += (sender, args) => OnTimeChanged(DateTime.Now);
            timer.Start();
            
            base.OnApplyTemplate();
        }

        // virtual. Makes it overridable
        protected virtual void OnTimeChanged(DateTime time)
        {
            // 1:::: Update teh UI
            UpdateHandAngles(time);
            
            // 2:::: Rise the event so the Parent View understands
            // TODO: Handle Old and New Value in a better way 
            RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>(DateTime.Now.AddSeconds(-1), DateTime.Now, TimeChangedEvent));
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
