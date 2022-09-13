using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_task.Core
{
    public class TimeManger
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; set; }
        public bool IsTimerStarted { get; set; }
        /// <summary>
        /// create timer with Action
        /// </summary>
        /// <param name="action">Action Type</param>
        public TimeManger (Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent (false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 10000);
            TimerStarted = DateTime.Now;
            IsTimerStarted = true;

        }

        //Dispose timer after one Hour
        public void Execute(object sateInfo)
        {
            _action();
            if((DateTime.Now - TimerStarted).TotalSeconds > 3600)
            {
                IsTimerStarted = false;
                _timer.Dispose();
            }
        }
    }
}
