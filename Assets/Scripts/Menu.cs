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
    
    [Header("Enemy Manager")] 
    [SerializeField] private EnemyController enemy;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    
    private CommandInvoker _commandInvoker;
    
    private ScoreController _scoreController;
    private DependencyContainer _container;
    
        
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

    }

    private void Injection()
    {
        
    }
        
    private void Init()
    {

    }

    
}