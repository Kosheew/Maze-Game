using Enemy;
using InitGame.Audio;
using InitGame.Level;
using Character;
using UnityEngine;
using UnityEngine.Serialization;
using UserController;

public class Game : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private UserInterface userInterface;
        
    [Header("Player Settings")]
    [SerializeField] private Character.Player player;
        
    [Header("Level Timer")]
    [SerializeField] private Timer timeLevel;
        
    [Header("UI Panels")]
    [SerializeField] private ViewPanels viewPanels;
        
    [Header("Game Completion")]
    [SerializeField] private GameCompleted gameCompleted;
        
    [FormerlySerializedAs("character")]
    [FormerlySerializedAs("enemyStateManager")]
    [Header("Enemy Manager")]
    [SerializeField] private Enemy.Enemy enemy;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    
    [FormerlySerializedAs("audioSettings")] [SerializeField] private CharacterAudioSettings characterAudioSettings;
    
    private ScoreController _scoreController;
    private DependencyContainer _container;
    private StateManager _stateManager;
    private StateFactory _stateFactory;
    
    private IUserController _userController;
        
    private void Awake()
    {
        _container = new DependencyContainer();
        _scoreController = new ScoreController();
        _userController = new WindowsController();
        _stateManager = new StateManager();
        _stateFactory = new StateFactory();
        
        RegisterDependency();
            
        Injection();
            
        Init();
    }

    private void RegisterDependency()
    {
        _container.Register(_userController);
        _container.Register(characterAudioSettings);
        _container.Register(_stateManager);
        //  _container.Register();
    }

    private void Injection()
    {
        player.Inject(_container);
    }
        
    private void Init()
    {
        //    audioManager.Init();
        //    gameCompleted.Init();
        //   _scoreController.Init();
        //   userInterface.Init();
        player.Init();
        // timeLevel.Init(_container);
        //   viewPanels.Init();
        //   enemyStateManager.Init(_container);
    }

}