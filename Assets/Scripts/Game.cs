using System;
using Wallet;
using InitGame.Audio;
using InitGame.Level;
using Characters;
using Characters.Enemy;
using Characters.Player;
using Commands;
using Keys;
using Timer;
using Unity.VisualScripting;
using UnityEngine;
using UserController;

public class Game : MonoBehaviour
{
    [Header("View Components")]
    [SerializeField] private WalletView walletView;
    [SerializeField] private TimerView timerView;
        
    [Header("Player Settings")]
    [SerializeField] private PlayerController player;
        
    /*[Header("Level Timer")]
    [SerializeField] private Timer timeLevel;*/
        
    [Header("UI Panels")]
    [SerializeField] private ViewPanels viewPanels;
        
    [Header("Game Completion")]
    [SerializeField] private GameCompleted gameCompleted;
    
    [Header("Enemy Manager")] 
    [SerializeField] private EnemyController[] enemies;

    [Header("Key Manager")] 
    [SerializeField] private Key[] keys;
    
    [Header("Audio Settings")]
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private CharacterAudioSettings characterAudioSettings;
    
    private CommandInvoker _commandInvoker;
    
    private WalletModel _wallet;
    private TimerModel _timer;
    
    private DependencyContainer _container;
    
    private StateEnemyManager _stateEnemyManager;
    private StatePlayerManager _statePlayerManager;
    
    private StateEnemyFactory _stateEnemyFactory;
    private StatePlayerFactory _statePlayerFactory;

    private CommandPlayerFactory _commandPlayerFactory;
    private CommandEnemyFactory _commandEnemyFactory;
    
    private IUserController _userController;
        
    private void Awake()
    {
        _container = new DependencyContainer();
        
        _wallet = new WalletModel(keys.Length);
        _timer = new TimerModel();
        
        _userController = new WindowsController();
        
        _commandInvoker = new CommandInvoker();
        
        _stateEnemyManager = new StateEnemyManager();
        _statePlayerManager = new StatePlayerManager();
        
        _stateEnemyFactory = new StateEnemyFactory();
        _statePlayerFactory = new StatePlayerFactory();
        
        _commandEnemyFactory = new CommandEnemyFactory();
        _commandPlayerFactory = new CommandPlayerFactory();
        
        RegisterDependency();
            
        Injection();
            
        Init();
        
        InitView();
    }

    private void RegisterDependency()
    {
        _container.Register(_userController);
        
        _container.Register(_commandInvoker);
        
        _container.Register(_wallet);
        _container.Register(audioManager);
        
        _container.Register(characterAudioSettings);
        
        _container.Register(_stateEnemyManager);
        _container.Register(_statePlayerManager);
        
        _container.Register(_stateEnemyFactory);
        _container.Register(_statePlayerFactory);
        
        _container.Register(_commandEnemyFactory);
        _container.Register(_commandPlayerFactory);
        _container.Register<IPlayer>(player);
        
    }

    private void Injection()
    {
        _commandPlayerFactory.Inject(_container);
        _commandEnemyFactory.Inject(_container);
        
        player.Inject(_container);

        foreach (var enemy in enemies)
        {
            enemy.Inject(_container);
        }

        foreach (var key in keys)
        {
            key.Inject(_container);
        }
    }
        
    private void Init()
    {
           audioManager.Init();
        //    gameCompleted.Init();
        //   _scoreController.Init();
        //   userInterface.Init();
       // player.Inject(_container);
        // timeLevel.Init(_container);
        //   viewPanels.Init();
        //   enemyStateManager.Init(_container);
    }

    private void InitView()
    {
        new WalletController(_wallet, walletView);
        new TimerController(_timer, timerView);
    }


    private void Update()
    {
        foreach (var enemy in enemies)
        {
            _stateEnemyManager?.UpdateState(enemy);
        }
    }

    private void OnDestroy()
    {
        _timer.StopTimer();
    }
}