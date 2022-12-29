using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Tools;

namespace MainThread
{
    public class TimeElapse
    {
        private Timer _timer;
        private int _count = 0;
        private string str;
        private int repetition;
        public void DisplayEveryXMs(string writeline, float ms, int rep)
        {
            _timer = new Timer(ms);
            str = writeline;
            repetition = rep;
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();
            System.Threading.Thread.Sleep((int)(ms * rep) + 1000);
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (_count >= repetition) { _timer.Stop(); _count = 0; }
            else
            {
                Displayer.WriteLine(str, ConsoleColor.White);
                _count++;
            }
        }
    }
}
