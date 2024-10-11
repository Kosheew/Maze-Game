using CustomEventBus;
using CustomEventBus.Signals;
using InitGame.Audio;
using UnityEngine;

namespace GameKeys 
{
    /// <summary>
    /// Represents a collectible key object that the player can interact with.
    /// Implements the ITouching interface to handle interaction events.
    /// </summary>
    public class Key : MonoBehaviour, ITouching
    {
        [SerializeField] private AudioClip _pickUpSound;
        private AudioManager _audioManager;

        private void Start()
        {
            _audioManager = ServiceLocator.Current.Get<AudioManager>();
        }
        /// <summary>
        /// Called when the player touches the key.
        /// This method triggers the OnAddKey event to update the score and deactivates the key object.
        /// </summary>
        /// <param name="eventBus">The EventBus instance used for broadcasting events.</param>
        public void Touch(EventBus eventBus)
        {
            eventBus?.Invoke(new OnAddKey()); // Trigger the OnAddKey event to notify score increase.
            _audioManager.PlaySound(_pickUpSound);
            gameObject.SetActive(false); // Deactivate the key object to indicate it has been collected.
        }
    }
}
