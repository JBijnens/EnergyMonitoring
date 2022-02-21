using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    internal class TimingManager
    {
        private static TimingManager current;
        public static TimingManager Current
        {
            get
            {
                if (current == null)
                {
                    current = new TimingManager();
                }
                return current;
            }
        }

        private Timer timer = null;
        public Action<object?> Callback { get; set; }

        private TimingManager()
        {
            timer = new Timer(timerCallback);
            timer.Change(1000 * 5, 1000 * 60 * 5);
            //timer.Change(1000 * 5, 1000 * 10);
        }

        private void timerCallback(object? state)
        {
            if (Callback != null) Callback(state);
        }
    }
}
