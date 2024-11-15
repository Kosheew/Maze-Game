using Character;
using UnityEngine.AI;
using UnityEngine;
using Enemy.State;
using Enemy.Command;
using Player;

namespace Enemy
{
    public class Enemy : MonoBehaviour, ICharacter
    {
        private IFootstepHandler _footstepHandler;

        [SerializeField] private Transform[] targets;
        [SerializeField] private float chaseDistance = 3f;
        [SerializeField] private float attackDistance = 1.5f;
        [SerializeField] private float rotationSpeed = 5f;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] footstepClips;
        [SerializeField] private AudioClip attackClip;
        [SerializeField] private float footstepInterval = 0.5f;

        private Transform _player;
        private NavMeshAgent _agent;
        private Animator _animator;
        private int _currentIndex = 0;
        
        private StateManager _stateManager;
        private CommandCharacterFactory _commandFactory;
        
        public void Init(DependencyContainer container)
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

          //  _footstepHandler = new FootstepHandler(audioSource, footstepClips, footstepInterval);
          

            _player = container.Resolve<PlayerController>().transform;
            _stateManager = container.Resolve<StateManager>();
            _commandFactory = container.Resolve<CommandCharacterFactory>();

            _commandFactory.CreatePatrolledCommand(this);
        }

        private void Update()
        {
            _stateManager.UpdateState(this);
        }

        private ICharacterState GetCurrentState()
        {
            return _stateManager.CurrentState;
        }
        
        public void StopMovement()
        {
            _agent.isStopped = true;
        }

        public void ResumeMovement()
        {
            _agent.isStopped = false;
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
        
        public bool HasReachedDestination()
        {
            return _agent.remainingDistance < 0.01f;
        }
        
        public void SetNextPatrolPoint()
        {
            _currentIndex = (_currentIndex + 1) % targets.Length;

            var rotateCommand = new RotateTowardsCommand(transform, targets[_currentIndex].position, rotationSpeed);
            rotateCommand.Execute();
            _footstepHandler.PlayFootstepSound();
            new SetDestinationCommand(_agent, targets[_currentIndex].position).Execute();
        }
        
        /*
        public void SetChaseDestination()
        {
            if (!IsPlayerInAttackRange())
            {
                var rotateCommand = new RotateTowardsCommand(transform, _player.position, rotationSpeed);
                rotateCommand.Execute();
                _footstepHandler.PlayFootstepSound();
                new SetDestinationCommand(_agent, _player.position).Execute();
            }
            else
            {
                StopMovement();
            }
        }
        */
        
        public void AttackPlayer()
        {
          //  new AttackCommand(_animator, attackClip, audioSource).Execute();
        }
        
        public void SetAnimation(string param, bool value)
        {
            _animator.SetBool(param, value);
        }
    }
}
