using CustomEventBus;
using CustomEventBus.Signals;
using System;

namespace InitGame.Level
{
    /// <summary>
    /// Manages the game's score, updating it when keys are collected.
    /// Implements the IService and IDisposable interfaces for initialization and cleanup.
    /// </summary>
    public class ScoreController : IService, IDisposable
    {
        private EventBus _eventBus; // Event bus for subscribing to score-related events.
        private int _score; // Current score of the player.

        /// <summary>
        /// Initializes the ScoreController by subscribing to relevant events.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>(); // Retrieve the EventBus instance.
            _eventBus.Subscribe<OnAddKey>(OnScoreAdded); // Subscribe to key addition events.
        }

        /// <summary>
        /// Increases the score when a key is collected and broadcasts the updated score.
        /// </summary>
        /// <param name="signal">The OnAddKey signal indicating a key has been collected.</param>
        private void OnScoreAdded(OnAddKey signal)
        {
            _score++; // Increment the score.
            _eventBus.Invoke(new OnScoreChange(_score)); // Broadcast the updated score.
        }

        /// <summary>
        /// Unsubscribes from events to prevent memory leaks.
        /// </summary>
        public void Dispose()
        {
            _eventBus.Unsubscribe<OnAddKey>(OnScoreAdded); // Unsubscribe from key addition events.
        }
    }
}
