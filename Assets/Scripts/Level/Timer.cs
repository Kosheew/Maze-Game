using System.Collections;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

namespace Game.Level
{
    public class Timer : MonoBehaviour, IService
    {
        private int _time = 0;
        private EventBus _eventBus;

        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();

            StartCoroutine(TimerUpdate());
        }

        IEnumerator TimerUpdate()
        {
            while (true)
            {
                _time += 1;

                int seconds = _time % 60;
                int minutes = _time / 60;

                string timer = string.Format("{00:00} : {01:00}", minutes, seconds);
                _eventBus?.Invoke(new OnTimerChange(timer));
                yield return new WaitForSeconds(1f);
            }
        }    
    }
}