using System;
using System.Windows;
using System.Windows.Controls;

namespace BinaryClock
{
    public partial class ClockControl : UserControl
    {
        public static readonly DependencyProperty CurretTimeProperty =
            DependencyProperty.Register("CurrentTime", typeof(DateTime), typeof(ClockControl), new UIPropertyMetadata(DateTime.Now, new PropertyChangedCallback(TimeChangedCallBack)));

        public ClockControl()
        {
            InitializeComponent();
        }

        static void TimeChangedCallBack(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            ClockControl control = (ClockControl)property;
            control.CurrentTime = (DateTime)args.NewValue;
        }


        public DateTime CurrentTime
        {
            get { return (DateTime)GetValue(CurretTimeProperty); }
            set
            {
                SetValue(CurretTimeProperty, value);
                SetTime();
            }
        }

        private void SetTime()
        {
            int hour = CurrentTime.Hour;
            int minute = CurrentTime.Minute;
            int second = CurrentTime.Second;
            string sHour = hour.ToString("00");
            string sMinute = minute.ToString("00");
            string sSecond = second.ToString("00");

            Block1(Convert.ToString(int.Parse(sHour[0].ToString()),2));
            Block2(Convert.ToString(int.Parse(sHour[1].ToString()), 2));

            Block3(Convert.ToString(int.Parse(sMinute[0].ToString()), 2));
            Block4(Convert.ToString(int.Parse(sMinute[1].ToString()), 2));

            Block5(Convert.ToString(int.Parse(sSecond[0].ToString()), 2));
            Block6(Convert.ToString(int.Parse(sSecond[1].ToString()), 2));
        }

        #region Blocks
        private void Block1(string binary)
        {
            if (binary.Length < 2)
                binary = "0" + binary;
            H_F1.IsActive = Activate(binary[1]);
            H_F2.IsActive = Activate(binary[0]);
        }

        private void Block2(string binary)
        {
           while(binary.Length < 4)
           {
               binary = "0" + binary;
           }
           H_S1.IsActive = Activate(binary[3]);
           H_S2.IsActive = Activate(binary[2]);
           H_S3.IsActive = Activate(binary[1]);
           H_S4.IsActive = Activate(binary[0]);
        }

        private void Block3(string binary)
        {
            while (binary.Length < 3)
            {
                binary = "0" + binary;
            }
            M_F1.IsActive = Activate(binary[2]);
            M_F2.IsActive = Activate(binary[1]);
            M_F3.IsActive= Activate(binary[0]);
        }

        private void Block4(string binary)
        {
            while (binary.Length < 4)
            {
                binary = "0" + binary;
            }
            M_S1.IsActive = Activate(binary[3]);
            M_S2.IsActive = Activate(binary[2]);
            M_S3.IsActive = Activate(binary[1]);
            M_S4.IsActive = Activate(binary[0]);
        }

        private void Block5(string binary)
        {
            while (binary.Length < 3)
            {
                binary = "0" + binary;
            }
            S_F1.IsActive = Activate(binary[2]);
            S_F2.IsActive = Activate(binary[1]);
            S_F3.IsActive = Activate(binary[0]);
        }

        private void Block6(string binary)
        {
            while (binary.Length < 4)
            {
                binary = "0" + binary;
            }
            S_S1.IsActive = Activate(binary[3]);
            S_S2.IsActive = Activate(binary[2]);
            S_S3.IsActive = Activate(binary[1]);
            S_S4.IsActive = Activate(binary[0]);
        }

        private bool Activate(char flag)
        {
            return flag.Equals('1');
        }
        #endregion
    }
}
