using UnityEngine;

namespace Player
{
    /// <summary>
    /// Handles player touch interactions using Unity's trigger detection system. 
    /// This component detects when the player touches objects that implement the ITouching interface.
    /// </summary>
    public class PlayerTouch : MonoBehaviour
    {

        /// <summary>
        /// Initializes the PlayerTouch component with an instance of the EventBus.
        /// </summary>
        /// <param name="eventBus">The EventBus used for broadcasting touch events.</param>
        public void Init()
        {
        }

        /// <summary>
        /// Triggered when the player's collider enters another trigger collider.
        /// If the other object implements the ITouching interface, the Touch method is invoked.
        /// </summary>
        /// <param name="other">The collider of the other object.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITouching touch))
            {
                // Calls the Touch method of the object, passing in the EventBus for event handling.

            }
        }
    }
}
