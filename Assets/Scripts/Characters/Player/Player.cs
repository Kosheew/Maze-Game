using UnityEngine;
using Character;
using UserController;

namespace Character
{
    public class Player : MonoBehaviour, ICharacter
    {
        public CharacterController CharacterController { get; private set; }
        public AudioSettings AudioSettings { get; private set; }
        public Camera CameraMain { get; private set; }
        public IFootstepHandler FootstepHandler { get; private set; }
        public IUserController UserController { get; private set; }
        public IMovement Movement { get; private set; }
        
        [SerializeField] private AudioSource audioSource;           

        [SerializeField] private float maxClamp = 60;
        [SerializeField] private float speedScale = 5f;
        [SerializeField] private float turnSpeed = 250f;
        [SerializeField] private float accelerationRate = 2f;
        
        private StateManager _stateManager;
        private CommandCharacterFactory _commandFactory;
        
        public void Inject(DependencyContainer container)
        {
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandCharacterFactory>();
            
            CharacterController = GetComponent<CharacterController>();
            UserController = container.Resolve<IUserController>();
            AudioSettings = container.Resolve<AudioSettings>();
            
            Movement = new CharacterMovement(maxClamp, speedScale, accelerationRate, turnSpeed);
            FootstepHandler = new FootstepHandler(audioSource, AudioSettings);
            CameraMain = Camera.main;
            
            _commandFactory.CreateMoveCommand(this);
        }
        
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update()
        {
            _stateManager.UpdateState(this);
        }
    }
}