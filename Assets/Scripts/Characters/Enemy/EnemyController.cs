using Characters.Player;
using CharacterSettings;
using Commands;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyController : MonoBehaviour, IEnemy
    {
        [SerializeField] private Transform[] patrolTargets;
        [SerializeField] private EnemySetting enemySetting;
        [SerializeField] private AudioSource audioSource;
         
        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();
        private Animator Animator => GetComponent<Animator>();
        public EnemySetting EnemySetting => enemySetting;
        
        public Transform[] PatrolTargets => patrolTargets;
        public Transform CurrentTarget => _currentTarget;
        public CharacterAnimator CharacterAnimator { get; private set; }
        public IFootstepHandler FootstepHandler { get; private set; }
        public Transform MainPosition => transform;

        private CharacterAudioSettings _characterAudioSettings;
        private Transform _currentTarget;
        private StateEnemyManager _stateEnemyManager;
        private CommandEnemyFactory _commandFactory;
        

        public void Inject(DependencyContainer container)
        {
            Agent.speed = enemySetting.MoveSpeed;
            
            _characterAudioSettings = enemySetting.CharacterAudioSettings;
            
            _currentTarget = container.Resolve<PlayerController>().TransformMain;
            _stateEnemyManager = container.Resolve<StateEnemyManager>();
            _commandFactory = container.Resolve<CommandEnemyFactory>();

            FootstepHandler = new FootstepHandler(audioSource, _characterAudioSettings);
            CharacterAnimator = new CharacterAnimator(Animator);
            
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
                Debug.Log("Chase");
                _commandFactory.CreateChasingCommand(this);
            }
        }
        
        public void TargetInAttackRange(float distance)
        {
            if (Vector3.Distance(transform.position, _currentTarget.position) < distance && _currentTarget)
            {
                Debug.Log("I Attacked");
                _commandFactory.CreateAttackCommand(this);
            }
        }
        
        public void TargetNotInChaseRange(float distance)
        {
            if (Vector3.Distance(transform.position, _currentTarget.position) > distance && _currentTarget)
            {
                _commandFactory.CreatePatrolledCommand(this);
            }
        }
    }
}
