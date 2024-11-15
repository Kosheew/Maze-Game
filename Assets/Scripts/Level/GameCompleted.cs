using UnityEngine;

namespace InitGame.Level
{
    public class GameCompleted : MonoBehaviour
    {
       

        /// <summary>
        /// Gets the maximum number of keys that need to be collected to complete the game.
        /// </summary>
        public int MaxKeys { get; private set; }

        /// <summary>
        /// Initializes the GameCompleted instance by calculating the maximum keys and subscribing to events.
        /// </summary>
        public void Init()
        {

        }
        
        private void ScoreChange()
        {
           
        }

    }
}
