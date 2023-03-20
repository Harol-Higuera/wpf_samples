using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CustomControlsInheritance.Views
{
    public class Clock: Control
    {
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
        protected virtual void OnTimeChanged(DateTime time)
        {
            // 2:::: Update TimeState
            UpdateTimeState(time);

            // 3:::: Rise the event so the Parent View understands
            // TODO: Handle Old and New Value in a better way 
            RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>(DateTime.Now.AddSeconds(-1), DateTime.Now, TimeChangedEvent));
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
