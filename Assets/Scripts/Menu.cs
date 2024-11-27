using System;
using InitGame.Audio;
using InitGame.Level;
using Characters;
using Characters.Enemy;
using Characters.Player;
using Commands;
using UnityEngine;
using UserController;

public class Menu: MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private UserInterface userInterface;

    [Header("UI Panels")]
    [SerializeField] private ViewPanels viewPanels;
        
    [Header("Game Completion")]
    [SerializeField] private GameCompleted gameCompleted;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private MainView mainView;
    [SerializeField] private LoadingScene loadingScene;
    
    private CommandInvoker _commandInvoker;
    
    private ScoreController _scoreController;
    private DependencyContainer _container;
    private LoadingScene _loadingScene;
        
    private void Awake()
    {
        _container = new DependencyContainer();
        _scoreController = new ScoreController();
        
        _commandInvoker = new CommandInvoker();
        
        RegisterDependency();
            
        Injection();
            
        Init();
    }

    private void RegisterDependency()
    {
        _container.Register(_commandInvoker);
        _container.Register(_loadingScene);
    }

    private void Injection()
    {
        
    }
        
    private void Init()
    {
        var presenter = new MainPresenter(loadingScene);
        mainView.Init(presenter);
    }

    
}