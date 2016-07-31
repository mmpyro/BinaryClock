using System;

namespace BinaryClock
{
    public class Locator
    {
        static Locator()
        {
            Clock = new ClockVm(DateTime.Now);
        }

        public static void Close()
        {
            if(Clock != null)
                Clock.Close();
        }

        public static ClockVm Clock { get; private set; }
    }
}
