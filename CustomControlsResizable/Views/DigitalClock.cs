using System;
using System.Windows;

namespace CustomControlsResizable.Views
{
    [TemplatePart(Name = "PART_Colon", Type = typeof(UIElement))]
    public class DigitalClock: Clock
    {
        /// <summary>
        /// This UI element is very generic because the only thing that we need is to control the visibility
        /// </summary>
        private UIElement? _colon;

        /// <summary>
        /// Dependency Property to update the Colon Blink
        /// </summary>
        public static readonly DependencyProperty ColonBlinkProperty = DependencyProperty.Register(nameof(ColonBlink), typeof(bool), typeof(DigitalClock), new PropertyMetadata(true));
        public bool ColonBlink
        {
            get => (bool)GetValue(ColonBlinkProperty);
            set => SetValue(ColonBlinkProperty, value);
        }

        static DigitalClock()
        {
            // Apply Styling to DigitalClock
            // Defined in DigitalClockStyle.xaml
            //
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalClock), new FrameworkPropertyMetadata(typeof(DigitalClock)));
        }

        public override void OnApplyTemplate()
        {
            _colon = Template.FindName("PART_Colon", this) as UIElement;
            base.OnApplyTemplate();
        }

        protected override void OnTimeChanged(DateTime newTime)
        {
            if (_colon != null)
            {
                if (ColonBlink && !ShowSeconds)
                {
                    _colon.Visibility = _colon.IsVisible ? Visibility.Hidden : Visibility.Visible;
                }
                else
                { 
                    _colon.Visibility = Visibility.Visible;
                }
            }

            base.OnTimeChanged(newTime);
        }
    }
}
