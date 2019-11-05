using RSS_Demo;
using RSS_Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimerHanterare;

namespace NyTimerKlass
{
    class NyTimer : TimerHantering
    {
        private int NyttInterval = UpdateIntervalRepo.LoadUpdateInterval();
        
        
        public override void Timer(int NyttInterval)
        {            

            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = NyttInterval;
            timer.Enabled = true;


        }
    }
}
