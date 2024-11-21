using UnityEngine;

using UserController;
using Commands;
using CharacterSettings;
using Audio;

namespace Characters.Player
{
    public class PlayerController : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerSetting playerSetting;
        [SerializeField] private AudioSource audioSource;
        public CharacterAudioSettings CharacterAudioSettings { get; private set; }
        public CharacterController Controller { get; private set; }
        public Camera CameraMain { get; private set; }
        public PlayerSetting PlayerSetting => playerSetting;
        public IFootstepAudioHandler FootstepHandler { get; private set; }
        public IUserController UserController { get; private set; }
        public Transform TransformMain => transform;

        private StatePlayerManager _statePlayerManager;
        private CommandPlayerFactory _commandFactory;
        
        public void Inject(DependencyContainer container)
        {
            _statePlayerManager = container.Resolve<StatePlayerManager>();
            _commandFactory = container.Resolve<CommandPlayerFactory>();
            
            Controller = GetComponent<CharacterController>();
            UserController = container.Resolve<IUserController>();
            CharacterAudioSettings = playerSetting.CharacterAudioSettings;
            
            FootstepHandler = new FootstepAudioAudioHandler(audioSource, CharacterAudioSettings);
            CameraMain = Camera.main;
            
            _commandFactory.CreateMoveCommand(this);
            
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update()
        {
            _statePlayerManager?.UpdateState(this);
        }
    }
}
