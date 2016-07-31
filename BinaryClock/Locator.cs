using System;

namespace BinaryClock
{
    public class Locator
    {
        static Locator()
        {
            Clock = new ClockVm(new DateTime(2016,7,31,15,47,11));
        }

        public static void Close()
        {
            if(Clock != null)
                Clock.Close();
        }

        public static ClockVm Clock { get; private set; }
    }
}
