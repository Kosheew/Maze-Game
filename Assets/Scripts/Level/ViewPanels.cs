using CustomEventBus;
using CustomEventBus.Signals;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace InitGame.Level
{
    /// <summary>
    /// Manages the display of UI panels for game end and pause functionality.
    /// Implements the IService and IDisposable interfaces for initialization and cleanup.
    /// </summary>
    public class ViewPanels : MonoBehaviour, IService, IDisposable
    {
        [SerializeField] private GameObject _endPanel; // Panel displayed when the game ends.
        [SerializeField] private GameObject _panelPause; // Panel displayed when the game is paused.
        [SerializeField] private TMP_Text _endText; // Text component for displaying end game messages.
        [SerializeField] private Button _playNextButton; // Button to trigger the next play action.

        private EventBus _eventBus; // Event bus for subscribing to game events.
        private bool _isGamePaused = false; // Tracks whether the game is currently paused.

        /// <summary>
        /// Initializes the ViewPanels by subscribing to game events and setting up the UI.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();
            _eventBus.Subscribe<OnGameEnd>(EndGame);
            _eventBus.Subscribe<OnGamePause>(Pause);

            Cursor.visible = false; // Hide the cursor.
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor.

            // Add listener for play next button to invoke pause event.
            _playNextButton.onClick.AddListener(() =>
            {
                _eventBus?.Invoke(new OnGamePause());
            });

            // Initialize UI panels to be inactive.
            _endPanel.SetActive(false);
            _panelPause.SetActive(false);
            SetTimeScale(_isGamePaused);
        }

        /// <summary>
        /// Handles the end game event, updating UI and unlocking the cursor.
        /// </summary>
        /// <param name="signal">The OnGameEnd signal containing the end message.</param>
        private void EndGame(OnGameEnd signal)
        {
            UnlockCursor(); // Unlock the cursor for UI interaction.
            _endText.text = signal.Value; // Update end game text.
            _endPanel.SetActive(true); // Show end game panel.
            SetTimeScale(_isGamePaused); // Set the game time scale.
        }

        /// <summary>
        /// Restarts the current game scene.
        /// </summary>
        public void RestartGame()
        {
            SetTimeScale(_isGamePaused); // Ensure correct time scale is set.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene.
        }

        /// <summary>
        /// Quits the application.
        /// </summary>
        public void QuitGame()
        {
            Application.Quit(); // Exit the application.
        }

        /// <summary>
        /// Handles the pause event, toggling the pause panel visibility and locking the cursor.
        /// </summary>
        /// <param name="signal">The OnGamePause signal for toggling pause state.</param>
        public void Pause(OnGamePause signal)
        {
            _panelPause.SetActive(_isGamePaused); // Show/hide pause panel.
            UnlockCursor(); // Unlock cursor for UI interaction.
            SetTimeScale(_isGamePaused); // Set the game time scale.
        }

        /// <summary>
        /// Sets the time scale based on the pause state.
        /// </summary>
        /// <param name="pause">Indicates whether the game should be paused.</param>
        private void SetTimeScale(bool pause)
        {
            _isGamePaused = !pause; // Toggle pause state.
            Time.timeScale = _isGamePaused ? 1 : 0; // Set the time scale to either normal or paused.
        }

        /// <summary>
        /// Unlocks or locks the cursor based on the game state.
        /// </summary>
        private void UnlockCursor()
        {
            Cursor.lockState = _isGamePaused ? CursorLockMode.None : CursorLockMode.Locked; // Lock or unlock cursor.
            Cursor.visible = !Cursor.visible; // Toggle cursor visibility.
        }

        /// <summary>
        /// Unsubscribes from event signals to prevent memory leaks.
        /// </summary>
        public void Dispose()
        {
            _eventBus.Unsubscribe<OnGameEnd>(EndGame);
            _eventBus.Unsubscribe<OnGamePause>(Pause);
        }
    }
}
