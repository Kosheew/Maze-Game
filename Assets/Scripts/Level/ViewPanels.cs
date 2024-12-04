using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace InitGame.Level
{

    public class ViewPanels : MonoBehaviour
    {
        [SerializeField] private GameObject _endPanel; // Panel displayed when the game ends.
        [SerializeField] private GameObject _panelPause; // Panel displayed when the game is paused.
        [SerializeField] private TMP_Text _endText; // Text component for displaying end game messages.
        [SerializeField] private Button _playNextButton; // Button to trigger the next play action.

    
        private bool _isGamePaused = false; // Tracks whether the game is currently paused.
        
        public void Init()
        {
         

            Cursor.visible = false; // Hide the cursor.
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor.

            // Add listener for play next button to invoke pause event.
            _playNextButton.onClick.AddListener(() =>
            {
               
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
        private void EndGame()
        {
            UnlockCursor(); // Unlock the cursor for UI interaction.
           
            _endPanel.SetActive(true); // Show end game panel.
            SetTimeScale(_isGamePaused); // Set the game time scale.
        }


        public void RestartGame()
        {
            SetTimeScale(_isGamePaused); // Ensure correct time scale is set.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene.
        }


        public void QuitGame()
        {
            Application.Quit(); // Exit the application.
        }


        public void Pause()
        {
            _panelPause.SetActive(_isGamePaused); // Show/hide pause panel.
            UnlockCursor(); // Unlock cursor for UI interaction.
            SetTimeScale(_isGamePaused); // Set the game time scale.
        }


        private void SetTimeScale(bool pause)
        {
            _isGamePaused = !pause; 
            Time.timeScale = _isGamePaused ? 1 : 0; 
        }


        private void UnlockCursor()
        {
            Cursor.lockState = _isGamePaused ? CursorLockMode.None : CursorLockMode.Locked; // Lock or unlock cursor.
            Cursor.visible = !Cursor.visible; // Toggle cursor visibility.
        }

      
    }
}
