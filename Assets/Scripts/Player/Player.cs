using CustomEventBus;
using CustomEventBus.Signals;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Manages player input, movement, and interactions in the game.
    /// Implements IService for service locator pattern integration.
    /// </summary>
    public class PlayerController : MonoBehaviour, IService
    {
        private const string Mouse_X = "Mouse X";
        private const string Mouse_Y = "Mouse Y";
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        private EventBus _eventBus;

        private float _mouseX = 0f;
        private float _mouseY = 0f;
        private float _vertical = 0f;
        private float _horizontal = 0f;

        private PlayerMovement _playerMovement;
        private PlayerTouch _playerTouch;
        private IFootstepHandler _footstepHandler;

        [SerializeField] private AudioSource _audioSource;             // Audio source for footstep sounds
        [SerializeField] private AudioClip[] _footstepClips;           // Array of footstep audio clips
        [SerializeField] private float _footstepInterval = 0.5f;       // Time interval between footstep sounds

        /// <summary>
        /// Initializes the PlayerController by acquiring necessary components and initializing dependencies.
        /// </summary>
        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();

            _playerMovement = GetComponent<PlayerMovement>();
            _playerTouch = GetComponent<PlayerTouch>();

            _playerTouch.Init(_eventBus);
            _playerMovement.Init();

            _footstepHandler = new FootstepHandler(_audioSource, _footstepClips, _footstepInterval);
        }

        /// <summary>
        /// Updates the player state each frame, handling input and invoking actions accordingly.
        /// </summary>
        void Update()
        {
            // Check for pause input
            if (Input.GetKeyDown(KeyCode.Escape))
                _eventBus?.Invoke(new OnGamePause());

            // Gather input values
            _mouseX = Input.GetAxis(Mouse_X);
            _mouseY = Input.GetAxis(Mouse_Y);
            _vertical = Input.GetAxis(Vertical);
            _horizontal = Input.GetAxis(Horizontal);

            // Manage acceleration based on shift key state
            if (Input.GetKeyDown(KeyCode.LeftShift))
                _playerMovement.AddAcseleration();
            if (Input.GetKeyUp(KeyCode.LeftShift))
                _playerMovement.SubAcseleration();

            // Rotate and move the player
            _playerMovement.RotatePlayer(_mouseX, _mouseY);
            _playerMovement.MoveCharacter(_horizontal, _vertical);

            // Play footstep sound if the player is moving
            if (IsMoving())
            {
                _footstepHandler.PlayFootstepSound();
            }
        }

        /// <summary>
        /// Determines if the player is currently moving based on input.
        /// </summary>
        /// <returns>True if the player is moving; otherwise, false.</returns>
        private bool IsMoving()
        {
            return Mathf.Abs(_horizontal) > 0.1f || Mathf.Abs(_vertical) > 0.1f;
        }
    }
}
