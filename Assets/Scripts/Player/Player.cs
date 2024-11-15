using UnityEngine;
using Character;
using UserController;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;
        private Camera _camera;
        private AudioSettings _audioSettings;
        
        private IFootstepHandler _footstepHandler;
        private IMovement _movement;
        private IUserController _userController;
        
        [SerializeField] private AudioSource audioSource;           
        [SerializeField] private AudioClip[] footstepClips;          
        [SerializeField] private float footstepInterval = 0.5f;

        [SerializeField] private float maxClamp = 60;
        [SerializeField] private float speedScale = 5f;
        [SerializeField] private float turnSpeed = 250f;
        [SerializeField] private float accelerationRate = 2f;
        
        public void Inject(DependencyContainer container)
        {
            _camera = Camera.main;
            _characterController = GetComponent<CharacterController>();
            _userController = container.Resolve<IUserController>();
            _audioSettings = container.Resolve<AudioSettings>();
            
            _movement = new CharacterMovement(maxClamp, speedScale, accelerationRate, turnSpeed);
            _footstepHandler = new FootstepHandler(audioSource, _audioSettings);
            
        }
        
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update()
        {
            var lookX = _userController.GetLookDirectionX();
            var lookY = _userController.GetLookDirectionY();
            var moveVertical = _userController.GetMoveDirectionVertical();
            var moveHorizontal = _userController.GetMoveDirectionHorizontal();

            _movement.RotateCharacter(lookX, lookY, transform, _camera.transform);
            var velocity =_movement.MoveCharacter(moveHorizontal, moveVertical, transform);
            var gravityVelocity = _movement.AddGravity();

            _characterController.Move(_characterController.isGrounded ? velocity : (Vector3)gravityVelocity);

            if (IsMoving(velocity))
            {
                _footstepHandler.PlayFootstepSound();
            }
        }

        private bool IsMoving(Vector3 velocity)
        {
            var velocityMagnitude = new Vector3(velocity.x, 0, velocity.z).magnitude;
            return velocityMagnitude > 0.01f;
        }
    }
}
