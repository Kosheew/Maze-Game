using System;
using System.Threading;

namespace Timer
{
    public class TimerModel
    {
        private readonly System.Timers.Timer _timer;
        private int _time = 0;
        private readonly SynchronizationContext _context;
        public event Action<int> OnTimeChanged;

        public TimerModel()
        {
            _context = SynchronizationContext.Current; 
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += (sender, args) =>
            {
                _time++;
                _context.Post(_ => OnTimeChanged?.Invoke(_time), null); 
            };
        }

        public void StartTimer() => _timer.Start();
        public void StopTimer() => _timer.Stop();
        
        public void ResetTimer()
        {
            _time = 0;
            _context.Post(_ => OnTimeChanged?.Invoke(_time), null);
        }
    }
}