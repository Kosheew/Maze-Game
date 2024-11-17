using Character;
using UnityEngine.AI;
using UnityEngine;
using Enemy.State;
using Enemy.Command;

namespace Enemy
{
    public class Enemy : MonoBehaviour, ICharacter
    {
        public IFootstepHandler FootstepHandler { get; private set; }

        [SerializeField] private Transform[] targets;
        [SerializeField] private float chaseDistance = 3f;
        [SerializeField] private float attackDistance = 1.5f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private AudioSource audioSource;
        
        public Transform[] Targets => targets;
        public float RotationSpeed => rotationSpeed;
        
        private AudioSettings _audioSettings;
        private Transform _player;
        public NavMeshAgent Agent { get; private set; }
        private Animator _animator;
        
        public int CurrentIndex { get; private set; }
        private StateManager _stateManager;
        private CommandCharacterFactory _commandFactory;
        
        public void Inject(DependencyContainer container)
        {
            Agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _player = container.Resolve<Player>().transform;
            _audioSettings = container.Resolve<AudioSettings>();
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandCharacterFactory>();

            FootstepHandler = new FootstepHandler(audioSource, _audioSettings);
            
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
        
        public void SetAnimation(string param, bool value)
        {
            _animator.SetBool(param, value);
        }
    }
}
