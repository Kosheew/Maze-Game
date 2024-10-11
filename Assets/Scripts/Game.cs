using CustomEventBus;
using System;
using System.Collections.Generic;
using UnityEngine;
using Player;
using InitGame.Level;
using Enemy;
using InitGame.Audio;

namespace InitGame
{
    /// <summary>
    /// The Game class is responsible for initializing game components, managing service registration,
    /// and handling the lifecycle of disposable objects during the game session.
    /// </summary>
    public class Game : MonoBehaviour
    {
        /// <summary>
        /// User interface component for handling in-game UI interactions.
        /// </summary>
        [Header("UI Components")]
        [SerializeField] private UserInterface _userInterface;

        /// <summary>
        /// Player controller component responsible for player actions.
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private PlayerController _player;

        /// <summary>
        /// Timer component for managing level time.
        /// </summary>
        [Header("Level Timer")]
        [SerializeField] private Timer _timeLevel;

        /// <summary>
        /// View panel manager for controlling the visibility of game panels.
        /// </summary>
        [Header("UI Panels")]
        [SerializeField] private ViewPanels _viewPanels;

        /// <summary>
        /// Game completion handler, responsible for tracking and triggering game completion events.
        /// </summary>
        [Header("Game Completion")]
        [SerializeField] private GameCompleted _gameComplated;

        /// <summary>
        /// Enemy state manager responsible for managing enemy AI behavior.
        /// </summary>
        [Header("Enemy Manager")]
        [SerializeField] private EnemyStateManager _enemyStateManager;

        [Header("Audio Manager")]
        [SerializeField] private AudioManager _audioManager;

        private EventBus _eventBus;
        private ScoreController _scoreController;
        private List<IDisposable> _disposables = new List<IDisposable>();

        /// <summary>
        /// Called when the script instance is being loaded. Initializes core services and game components.
        /// </summary>
        private void Awake()
        {
            _eventBus = new EventBus();
            _scoreController = new ScoreController();

            RegisterServices();
            Init();
            AddDisposables();
        }

        /// <summary>
        /// Registers necessary services into the service locator for global access.
        /// </summary>
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            ServiceLocator.Current.Register(_eventBus);
            ServiceLocator.Current.Register(_scoreController);
            ServiceLocator.Current.Register(_gameComplated);
            ServiceLocator.Current.Register(_userInterface);
            ServiceLocator.Current.Register(_player);
            ServiceLocator.Current.Register(_timeLevel);
            ServiceLocator.Current.Register(_viewPanels);
            ServiceLocator.Current.Register(_audioManager);
        }

        /// <summary>
        /// Initializes the components for the game session.
        /// </summary>
        private void Init()
        {
            _audioManager.Init();
            _gameComplated.Init();
            _scoreController.Init();
            _userInterface.Init();
            _player.Init();
            _timeLevel.Init();
            _viewPanels.Init();
            _enemyStateManager.Init();
        }

        /// <summary>
        /// Adds disposable objects to the list for proper cleanup when the game ends.
        /// </summary>
        private void AddDisposables()
        {
            _disposables.Add(_scoreController);
            _disposables.Add(_gameComplated);
            _disposables.Add(_userInterface);
            _disposables.Add(_viewPanels);
        }

        /// <summary>
        /// Called when the game object is destroyed. Ensures that all disposable resources are properly released.
        /// </summary>
        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
