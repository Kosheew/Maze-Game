using Character;
using Characters.Enemy;
using UnityEngine.AI;
using UnityEngine;
using Enemy.State;
using Enemy.Command;
using Commands;
using CharacterSettings;
using UnityEngine.Serialization;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private NavMeshAgent _agent;
        [SerializeField] private Transform[] patrolTargets;
        [SerializeField] private CharacterSetting characterSetting;
        private FootstepHandler _footstepHandler;

        public NavMeshAgent Agent => _agent;
        public Transform[] PatrolTargets => patrolTargets;

        public IFootstepHandler FootstepHandler => _footstepHandler;

        public CharacterSetting CharacterSetting
        {
            get => characterSetting;
            set => characterSetting = value;
        }

        [SerializeField] private float chaseDistance = 3f;
        [SerializeField] private float attackDistance = 1.5f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private AudioSource audioSource;
        
        public float RotationSpeed => rotationSpeed;
        
        private CharacterAudioSettings _characterAudioSettings;
        private Transform _player;
        private Animator _animator;
        
        public int CurrentIndex { get; private set; }
        private StateManager _stateManager;
        private CommandEnemyFactory _commandFactory;
        private CharacterAnimator _characterAnimator;

        public void Inject(DependencyContainer container)
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _characterAnimator = new CharacterAnimator(_animator);
            
            _player = container.Resolve<Player>().transform;
            _characterAudioSettings = container.Resolve<CharacterAudioSettings>();
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandEnemyFactory>();

            _footstepHandler = new FootstepHandler(audioSource, _characterAudioSettings);
            
            _commandFactory.CreatePatrolledCommand(this);
        }

        private void Update()
        {
            _stateManager.UpdateState(this);
        }
        
        public void PlayerInChaseRange()
        {
            if (Vector3.Distance(transform.position, _player.position) < chaseDistance)
            {
                _commandFactory.CreateChasingCommand(this);
            }
        }
        
        public void PlayerInAttackRange()
        {
            if (Vector3.Distance(transform.position, _player.position) < attackDistance)
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
