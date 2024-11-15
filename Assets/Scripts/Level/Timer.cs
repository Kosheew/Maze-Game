using System.Collections;
using UnityEngine;

namespace InitGame.Level
{
    public class Timer : MonoBehaviour
    {
        private ViewPanels _viewPanels;
        private int _time = 0; 
        
        public void Init(DependencyContainer container)
        {
            _viewPanels = container.Resolve<ViewPanels>();
            StartCoroutine(TimerUpdate()); 
        }
        
        private IEnumerator TimerUpdate()
        {
            while (true)
            {
                _time += 1; // Increment the time by one second.

                // Calculate minutes and seconds from the total time.
                var seconds = _time % 60;
                var minutes = _time / 60;

                // Format the timer string as "MM : SS".
                var timer = $"{minutes:00} : {seconds:00}";
               // _viewPanels.
                yield return new WaitForSeconds(1f); // Wait for one second before updating again.
            }
        }
    }
}
