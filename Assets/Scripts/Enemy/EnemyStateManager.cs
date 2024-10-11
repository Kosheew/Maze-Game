using UnityEngine.AI;
using UnityEngine;
using Enemy.State;
using Enemy.Command;
using Player;

namespace Enemy
{
    /// <summary>
    /// Manages the enemy's states and behaviors in the game.
    /// </summary>
    public class EnemyStateManager : MonoBehaviour, IService
    {
        public IEnemyState CurrentState { get; private set; }
        public IEnemyState PatrollingState { get; private set; }
        public IEnemyState ChasingState { get; private set; }
        public IEnemyState AttackingState { get; private set; }

        private IFootstepHandler _footstepHandler;

        [SerializeField] private Transform[] _targets;
        [SerializeField] private float _chaseDistance = 3f;
        [SerializeField] private float _attackDistance = 1.5f;
        [SerializeField] private float _rotationSpeed = 5f;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _footstepClips;
        [SerializeField] private AudioClip _attackClip;
        [SerializeField] private float _footstepInterval = 0.5f;

        private Transform _player;
        private NavMeshAgent _agent;
        private Animator _animator;
        private int _currentIndex = 0;

        /// <summary>
        /// Initializes the enemy state manager and its states.
        /// </summary>
        public void Init()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            _footstepHandler = new FootstepHandler(_audioSource, _footstepClips, _footstepInterval);

            PatrollingState = new PatrollingState();
            ChasingState = new ChasingState();
            AttackingState = new AttackingState();

            _player = ServiceLocator.Current.Get<PlayerController>().gameObject.transform;

            CurrentState = PatrollingState;
            CurrentState.EnterState(this);
        }

        private void Update()
        {
            CurrentState.UpdateState(this);
        }

        public void StopMovement()
        {
            _agent.isStopped = true;
        }

        public void ResumeMovement()
        {
            _agent.isStopped = false;
        }

        /// <summary>
        /// Switches the enemy state to the new state provided.
        /// </summary>
        /// <param name="newState">The new state to switch to.</param>
        public void SwitchState(IEnemyState newState)
        {
            CurrentState = newState;
            newState.EnterState(this);
        }

        /// <summary>
        /// Checks if the player is within chase range.
        /// </summary>
        /// <returns>True if the player is within chase distance; otherwise, false.</returns>
        public bool IsPlayerInChaseRange()
        {
            return Vector3.Distance(transform.position, _player.position) < _chaseDistance;
        }

        /// <summary>
        /// Checks if the player is within attack range.
        /// </summary>
        /// <returns>True if the player is within attack distance; otherwise, false.</returns>
        public bool IsPlayerInAttackRange()
        {
            return Vector3.Distance(transform.position, _player.position) < _attackDistance;
        }

        /// <summary>
        /// Checks if the enemy has reached its destination.
        /// </summary>
        /// <returns>True if the destination is reached; otherwise, false.</returns>
        public bool HasReachedDestination()
        {
            return _agent.remainingDistance < 0.01f;
        }

        /// <summary>
        /// Sets the next patrol point for the enemy.
        /// </summary>
        public void SetNextPatrolPoint()
        {
            _currentIndex = (_currentIndex + 1) % _targets.Length;

            var rotateCommand = new RotateTowardsCommand(transform, _targets[_currentIndex].position, _rotationSpeed);
            rotateCommand.Execute();
            _footstepHandler.PlayFootstepSound();
            new SetDestinationCommand(_agent, _targets[_currentIndex].position).Execute();
        }

        /// <summary>
        /// Sets the chase destination to the player's position.
        /// </summary>
        public void SetChaseDestination()
        {
            if (!IsPlayerInAttackRange())
            {
                var rotateCommand = new RotateTowardsCommand(transform, _player.position, _rotationSpeed);
                rotateCommand.Execute();
                _footstepHandler.PlayFootstepSound();
                new SetDestinationCommand(_agent, _player.position).Execute();
            }
            else
            {
                StopMovement();
            }
        }

        /// <summary>
        /// Executes the attack action on the player.
        /// </summary>
        public void AttackPlayer()
        {
            new AttackCommand(_animator, _attackClip, _audioSource).Execute();
        }

        /// <summary>
        /// Sets the animator parameter to control animations.
        /// </summary>
        /// <param name="param">The parameter name to set.</param>
        /// <param name="value">The value to set the parameter to.</param>
        public void SetAnimation(string param, bool value)
        {
            _animator.SetBool(param, value);
        }
    }
}
