using CustomEventBus;
using CustomEventBus.Signals;
using System;
using GameKeys;
using UnityEngine;

namespace InitGame.Level
{
    /// <summary>
    /// Manages the game's completion state, checking if all keys are collected.
    /// Implements the IService and IDisposable interfaces for initialization and cleanup.
    /// </summary>
    public class GameCompleted : MonoBehaviour, IService, IDisposable
    {
        private EventBus _eventBus; // Event bus for subscribing to score-related events.

        /// <summary>
        /// Gets the maximum number of keys that need to be collected to complete the game.
        /// </summary>
        public int MaxKeys { get; private set; }

        /// <summary>
        /// Initializes the GameCompleted instance by calculating the maximum keys and subscribing to events.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>(); // Retrieve the EventBus instance.
            MaxKeys = FindObjectsOfType<Key>().Length; // Count the total number of keys in the scene.
            _eventBus.Subscribe<OnScoreChange>(ScoreChange); // Subscribe to score change events.
        }

        /// <summary>
        /// Checks if the current score meets or exceeds the maximum keys required for completion.
        /// If completed, invokes the OnGameEnd event with a win message.
        /// </summary>
        /// <param name="signal">The OnScoreChange signal containing the current score.</param>
        private void ScoreChange(OnScoreChange signal)
        {
            if (signal.Value >= MaxKeys) // Check if the score is equal to or exceeds the max keys.
            {
                _eventBus?.Invoke(new OnGameEnd(StringConstant.Win)); // Trigger game end event with a win message.
            }
        }

        /// <summary>
        /// Unsubscribes from events to prevent memory leaks.
        /// </summary>
        public void Dispose()
        {
            _eventBus.Unsubscribe<OnScoreChange>(ScoreChange); // Unsubscribe from score change events.
        }
    }
}
