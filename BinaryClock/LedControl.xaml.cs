using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BinaryClock
{
    public partial class LedControl : UserControl
    {
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActiveProperty", typeof(bool), typeof(LedControl), new UIPropertyMetadata(null));

        public LedControl()
        {
            InitializeComponent();
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set
            {
                SetValue(IsActiveProperty, value);
                if (value)
                {
                    rect.Fill = Brushes.White;
                }
                else
                {
                    rect.Fill = Brushes.Black;
                }
            }
        }
    }
}
