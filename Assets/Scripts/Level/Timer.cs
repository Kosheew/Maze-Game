using System.Collections;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

namespace InitGame.Level
{
    /// <summary>
    /// Manages the in-game timer that updates every second.
    /// Implements the IService interface for initialization.
    /// </summary>
    public class Timer : MonoBehaviour, IService
    {
        private int _time = 0; // Total elapsed time in seconds.
        private EventBus _eventBus; // Event bus for broadcasting timer updates.

        /// <summary>
        /// Initializes the Timer and starts the timer update coroutine.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>(); // Retrieve the EventBus instance.
            StartCoroutine(TimerUpdate()); // Start the coroutine to update the timer.
        }

        /// <summary>
        /// Coroutine that updates the timer every second and broadcasts the updated time.
        /// </summary>
        /// <returns>An IEnumerator for coroutine execution.</returns>
        private IEnumerator TimerUpdate()
        {
            while (true)
            {
                _time += 1; // Increment the time by one second.

                // Calculate minutes and seconds from the total time.
                int seconds = _time % 60;
                int minutes = _time / 60;

                // Format the timer string as "MM : SS".
                string timer = string.Format("{0:00} : {1:00}", minutes, seconds);
                _eventBus?.Invoke(new OnTimerChange(timer)); // Broadcast the updated timer.

                yield return new WaitForSeconds(1f); // Wait for one second before updating again.
            }
        }
    }
}
