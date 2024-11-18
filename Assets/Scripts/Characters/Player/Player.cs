using UnityEngine;
using Character;
using UserController;
using Commands;
using CharacterSettings;

namespace Character
{
    public class Player : MonoBehaviour, ICharacter
    {
        public CharacterController CharacterController { get; private set; }
        public CharacterAudioSettings CharacterAudioSettings { get; private set; }
        public Camera CameraMain { get; private set; }
        public IFootstepHandler FootstepHandler { get; private set; }
        public IUserController UserController { get; private set; }
        public IMovement Movement { get; private set; }
        
        [SerializeField] private AudioSource audioSource;           

        [SerializeField] private CharacterSetting characterSetting;

        public CharacterSetting CharacterSetting
        {
            get => characterSetting;
            set => characterSetting = value;
        }
        
        [SerializeField] private float maxClamp = 60;
        [SerializeField] private float speedScale = 5f;
        [SerializeField] private float turnSpeed = 250f;
        [SerializeField] private float accelerationRate = 2f;
        
        private StateManager _stateManager;
        private CommandPlayerFactory _commandFactory;
        
        public void Inject(DependencyContainer container)
        {
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandPlayerFactory>();
            
            CharacterController = GetComponent<CharacterController>();
            UserController = container.Resolve<IUserController>();
            CharacterAudioSettings = container.Resolve<CharacterAudioSettings>();
            
            Movement = new CharacterMovement(maxClamp, speedScale, accelerationRate, turnSpeed);
            FootstepHandler = new FootstepHandler(audioSource, CharacterAudioSettings);
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
