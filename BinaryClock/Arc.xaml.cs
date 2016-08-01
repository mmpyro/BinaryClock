using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Math;

namespace BinaryClock
{

    public partial class ArcControl : UserControl
    {
        public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.Register("Radius", typeof(double), typeof(ArcControl), new UIPropertyMetadata(null));

        public static readonly DependencyProperty StartArcProperty =
        DependencyProperty.Register("StartArc", typeof(int), typeof(ArcControl), new UIPropertyMetadata(0, new PropertyChangedCallback(StartArcChangedCallBack)));

        public static readonly DependencyProperty EndArcProperty =
        DependencyProperty.Register("EndArc", typeof(int), typeof(ArcControl), new UIPropertyMetadata(360, new PropertyChangedCallback(EndArcChangedCallBack)));

        public static readonly DependencyProperty StrokeThicnessProperty =
        DependencyProperty.Register("StrokeThicness", typeof(int), typeof(ArcControl), new UIPropertyMetadata(2));

        public static readonly DependencyProperty StrokeColorProperty =
        DependencyProperty.Register("StrokeColor", typeof(Brush), typeof(ArcControl), new UIPropertyMetadata(Brushes.White));
        private double _size;

        public ArcControl()
        {
            InitializeComponent();
            Loaded += delegate
            {
                _size =( ActualWidth / 2.0);
                Draw();
            };
        }

        static void StartArcChangedCallBack(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            ArcControl control = (ArcControl)property;
            control.StartArc = (int)args.NewValue;
        }

        static void EndArcChangedCallBack(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            ArcControl control = (ArcControl)property;
            control.EndArc = (int)args.NewValue;
        }

        private void Draw()
        {
            IsValid();
            Canva.Children.Clear();
            double r = Radius - StrokeThicness;
            for (int i = StartArc; i < EndArc; i++)
            {
                var line = new Line
                {
                    X1 = _size + (r * Sin(Convert(i))),
                    Y1 = _size + (r * Cos(Convert(i))),
                    X2 = _size + (r * Sin(Convert(i + 1))),
                    Y2 = _size + (r * Cos(Convert(i + 1)))
                };
                line.Stroke = StrokeColor;
                line.StrokeThickness = StrokeThicness;
                Canva.Children.Add(line);
            }
        }

        private void IsValid()
        {
            if (Radius <= 0)
                throw new ArgumentException("Radius must be greater then 0");
        }

        private double Convert(int v)
        {
            return (v*PI)/180.0;
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set
            {
                SetValue(RadiusProperty, value);
            }
        }
        
        public int StartArc
        {
            get { return (int)GetValue(StartArcProperty); }
            set
            {
                SetValue(StartArcProperty, value);
                Draw();
            }
        }

        public int EndArc
        {
            get { return (int)GetValue(EndArcProperty); }
            set
            {

                SetValue(EndArcProperty, value);
                Draw();
            }
        }

        public int StrokeThicness
        {
            get { return (int)GetValue(StrokeThicnessProperty); }
            set { SetValue(StrokeThicnessProperty, value); }
        }

        public Brush StrokeColor
        {
            get { return (Brush)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }
    }
}
