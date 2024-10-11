using CustomEventBus;
using CustomEventBus.Signals;
using System;
using UnityEngine;
using TMPro;

namespace InitGame.Level
{
    /// <summary>
    /// Manages the user interface elements related to the game timer and score.
    /// Implements the IService and IDisposable interfaces for initialization and cleanup.
    /// </summary>
    public class UserInterface : MonoBehaviour, IService, IDisposable
    {
        [SerializeField] private TMP_Text _timerText; // Text component for displaying the timer.
        [SerializeField] private TMP_Text _scoreText; // Text component for displaying the score.

        private EventBus _eventBus; // Event bus for subscribing to game events.
        private GameCompleted _gameComplated; // Reference to the game completion state.
        private int _counter; // Maximum keys needed for game completion.

        /// <summary>
        /// Initializes the UserInterface by subscribing to game events and setting initial values.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>(); // Get the event bus instance.
            _gameComplated = ServiceLocator.Current.Get<GameCompleted>(); // Get the game completion state.
            _eventBus.Subscribe<OnTimerChange>(ChangeTimer); // Subscribe to timer change events.
            _eventBus.Subscribe<OnScoreChange>(ScoreChange); // Subscribe to score change events.
            _counter = _gameComplated.MaxKeys; // Get the maximum keys for scoring.

            _scoreText.text = $"0 / {_counter}"; // Initialize score text.
        }

        /// <summary>
        /// Updates the timer display based on the OnTimerChange signal.
        /// </summary>
        /// <param name="signal">The OnTimerChange signal containing the new timer value.</param>
        private void ChangeTimer(OnTimerChange signal)
        {
            _timerText.text = signal.Value; // Update the timer text.
        }

        /// <summary>
        /// Updates the score display based on the OnScoreChange signal.
        /// </summary>
        /// <param name="signal">The OnScoreChange signal containing the new score value.</param>
        private void ScoreChange(OnScoreChange signal)
        {
            _scoreText.text = $"{signal.Value} / {_counter}"; // Update the score text.
        }

        /// <summary>
        /// Unsubscribes from event signals to prevent memory leaks.
        /// </summary>
        public void Dispose()
        {
            _eventBus.Unsubscribe<OnTimerChange>(ChangeTimer); // Unsubscribe from timer change events.
            _eventBus.Unsubscribe<OnScoreChange>(ScoreChange); // Unsubscribe from score change events.
        }
    }
}
