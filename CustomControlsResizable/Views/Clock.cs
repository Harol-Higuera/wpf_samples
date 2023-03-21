using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CustomControlsInheritance.Views
{
    [TemplateVisualState(Name = "Day", GroupName = "TimeStates")]
    [TemplateVisualState(Name = "Night", GroupName = "TimeStates")]
    public class Clock: Control
    {
        /// <summary>
        /// Dependency Property for current time 
        /// </summary>
        // *** Using TimeCoerceValueCallback. Change the value in runtime ***
        //
        public static DependencyProperty TimeProperty = DependencyProperty.Register(
            nameof(Time),
            typeof(DateTime),
            typeof(Clock),
            new PropertyMetadata(DateTime.Now, TimePropertyChangedCallback, TimeCoerceValueCallback)
        );
        // *** Using TimeValidateValueCallback.rise an exception in runtime *** (For testing could be good)
        //
        //public static DependencyProperty TimeProperty = DependencyProperty.Register(
        //    nameof(Time),
        //    typeof(DateTime),
        //    typeof(Clock),
        //    new PropertyMetadata(DateTime.Now, TimePropertyChangedCallback),
        //    TimeValidateValueCallback
        //);

        public DateTime Time
        {
            get => (DateTime)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }
        // :::::::: Callback 1 :::::::::::::
        // Called BEFORE the Property Changed Callback
        // We can validate and return a boolean. If return FALSE an argument exception is raised
        // THE VALIDATION IS JUST AN EXAMPLE
        private static bool TimeValidateValueCallback(object value)
        {
            if (value is DateTime)
            {
                DateTime time = (DateTime)value;
                // If odd number
                if (time.Second % 2 == 1)
                {
                    return false;
                }
            }

            return true;
        }
        // :::::::: Callback 2 :::::::::::::
        // This Callback is used to modify the value in runtime
        // Called BEFORE the Property Changed Callback
        private static object TimeCoerceValueCallback(DependencyObject d, object baseValue)
        {
            if (baseValue is DateTime)
            {
                DateTime time = (DateTime)baseValue;
                // If odd number
                if (time.Second % 2 == 1)
                {
                    baseValue = time.AddSeconds(1);
                }
            }

            return baseValue;
        }
        // :::::::: Callback 3 :::::::::::::
        // This function is going to be called EVERY SINGLE TIME the dependency property changes
        // The dependency object is the Clock but we have to cast it.
        private static void TimePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Raise an event that a dependency property changed the value
            if (d is Clock clock)
            {
                clock.RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>((DateTime)e.OldValue, (DateTime)e.NewValue, TimeChangedEvent));
            }
        }

        /// <summary>
        /// Property to alter the UI from the cs View Class
        /// Concepts:
        ///  - DependencyProperty: Is a property for XAML controllers. Allow us to access the xaml components for styling, validation etc..
        /// </summary>
        public static DependencyProperty ShowSecondsProperty = DependencyProperty.Register(nameof(ShowSeconds), typeof(bool), typeof(Clock), new PropertyMetadata(true));
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
        public static RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(Clock));
        public event RoutedPropertyChangedEventHandler<DateTime> TimeChanged
        {
            add => AddHandler(TimeChangedEvent, value);
            remove => RemoveHandler(TimeChangedEvent, value);
        }

        public override void OnApplyTemplate()
        {

            OnTimeChanged(DateTime.Now);

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
        protected virtual void OnTimeChanged(DateTime newTime)
        {
            // 2:::: Update TimeState
            UpdateTimeState(newTime);

            // 3:::: Rise the event so the Parent View understands
            RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>(Time, Time, TimeChangedEvent));
            Time = newTime;
        }

        private void UpdateTimeState(DateTime time)
        {
            // Correct condition: if (time.Hour is > 6 and < 18)
            if (time.Second is > 10 and < 40)
            {
                VisualStateManager.GoToState(this, "Day", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "Night", false);
            }
        }
    }
}
