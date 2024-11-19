using Character;
using UnityEngine.AI;
using UnityEngine;
using Commands;
using CharacterSettings;
using Character.Enemy;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Transform[] patrolTargets;
        [SerializeField] private CharacterSetting characterSetting;
     
        private NavMeshAgent _agent;
        private Transform _currentTarget;
        
        public NavMeshAgent Agent => _agent;
        public Transform[] PatrolTargets => patrolTargets;
        public Transform CurrentTarget => _currentTarget;

        public IFootstepHandler FootstepHandler { get; private set; }
        public Transform MyPosition { get; set; }

        public CharacterSetting CharacterSetting
        {
            get => characterSetting;
            set => characterSetting = value;
        }

        [SerializeField] private AudioSource audioSource;

        private CharacterAudioSettings _characterAudioSettings;
        private Animator _animator;
        
        private StateEnemyManager _stateEnemyManager;
        private CommandEnemyFactory _commandFactory;
        private CharacterAnimator _characterAnimator;
        
        public void Inject(DependencyContainer container)
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            _agent.speed = CharacterSetting.MoveSpeed;
            
            _characterAudioSettings = characterSetting.CharacterAudioSettings;
            MyPosition = transform;
            
            _currentTarget = container.Resolve<Player>().transform;
            _stateEnemyManager = container.Resolve<StateEnemyManager>();
            _commandFactory = container.Resolve<CommandEnemyFactory>();

            FootstepHandler = new FootstepHandler(audioSource, _characterAudioSettings);
            _characterAnimator = new CharacterAnimator(_animator);
            
            _commandFactory.CreatePatrolledCommand(this);
        }

        private void Update()
        {
            _stateEnemyManager.UpdateState(this);
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
