using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;

namespace BinaryClock
{
    public class ClockVm : INotifyPropertyChanged
    {
        private DateTime _dt;
        private int _secondArc = 30;
        private int _minuteArc = -180;
        private int _hourArc = 210;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _ct;

        public ClockVm(DateTime dt)
        {
            _dt = dt;
            _ct = _tokenSource.Token;
            Task.Factory.StartNew(() => {
                while (!_ct.IsCancellationRequested)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Time = DateTime.Now;
                }
            }, TaskCreationOptions.LongRunning);
        }

        public DateTime Time
        {
            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
                Recalculate();
                Notify();
            }
        }

        public int SecStartArc
        {
            get
            {
                return _secondArc;
            }

            set
            {
                _secondArc = value;
                Notify();
            }
        }

        public int MinStartArc
        {
            get
            {
                return _minuteArc;
            }

            set
            {
                _minuteArc = value;
                Notify();
            }
        }

        public int HourEndArc
        {
            get
            {
                return _hourArc;
            }

            set
            {
                _hourArc = value;
                Notify();
            }
        }

        private void Recalculate()
        {
            SecStartArc = 30 + (int)Math.Round(1.6666 * _dt.Second);
            MinStartArc = (3 * _dt.Minute) - 180;
            HourEndArc =  210 - (int)Math.Round(14.1666*_dt.Hour);
        }

        public void Close()
        {
            _tokenSource.Cancel();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
