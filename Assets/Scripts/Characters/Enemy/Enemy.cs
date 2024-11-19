using Character;
using Characters.Enemy;
using UnityEngine.AI;
using UnityEngine;
using Enemy.State;
using Enemy.Command;
using Commands;
using CharacterSettings;
using CharacterSettings.StateSettings;
using UnityEngine.Serialization;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Transform[] patrolTargets;
        [SerializeField] private CharacterSetting characterSetting;
     
        private NavMeshAgent _agent;
        private IFootstepHandler _footstepHandler;
        private Transform _currentTarget;
        
        public NavMeshAgent Agent => _agent;
        public Transform[] PatrolTargets => patrolTargets;
        public Transform CurrentTarget => _currentTarget;

        public IFootstepHandler FootstepHandler => _footstepHandler;

        public CharacterSetting CharacterSetting
        {
            get => characterSetting;
            set => characterSetting = value;
        }
        
        [SerializeField] private AudioSource audioSource;

        private CharacterAudioSettings _characterAudioSettings;
        private Animator _animator;
        
        public int CurrentIndex { get; private set; }
        private StateManager _stateManager;
        private CommandEnemyFactory _commandFactory;
        private CharacterAnimator _characterAnimator;

        public ChasingState chasingState { get; private set; }
        
        public void Inject(DependencyContainer container)
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _characterAnimator = new CharacterAnimator(_animator);
            
            _currentTarget = container.Resolve<Player>().transform;
            _characterAudioSettings = container.Resolve<CharacterAudioSettings>();
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandEnemyFactory>();

            _footstepHandler = new FootstepHandler(audioSource, _characterAudioSettings);
            
        //    chasingState = (ChasingState)characterSetting.GetStateSettings(TypeCharacterStates.Chased);
            
            _commandFactory.CreatePatrolledCommand(this);
        }

        private void Update()
        {
            _stateManager.UpdateState(this);
        }
        
        public void TargetInChaseRange(float distance)
        {
            if (Vector3.Distance(transform.position, _currentTarget.position) < distance && _currentTarget)
            {
                _commandFactory.CreateChasingCommand(this);
            }
        }
        
        public void TargetInAttackRange(float distance)
        {
            if (Vector3.Distance(transform.position, _currentTarget.position) < distance && _currentTarget)
            {
                _commandFactory.CreateAttackCommand(this);
            }
        }

        public void PlayerRotateTarget()
        {
            _commandFactory.CharacterIdleCommand(this);
        }
        
        
    }
}
