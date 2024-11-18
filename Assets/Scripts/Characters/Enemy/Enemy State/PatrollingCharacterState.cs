using Character;
using Enemy.Command;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.State
{
    public class PatrollingCharacterState : ICharacterState
    {
        private Enemy _enemy;
        private int _currentIndex;
        private NavMeshAgent _agent;
        private IFootstepHandler _footstepHandler;
        private float _rotationSpeed;
        private Transform[] targets;
        
        public void EnterState(ICharacter character)
        {
            _enemy = (Enemy)character;
            _agent = _enemy.Agent;
            _currentIndex = 0;
            _footstepHandler = _enemy.FootstepHandler;
            targets = _enemy.Targets;
            
        }


        public void UpdateState(ICharacter character)
        {
            _enemy.PlayerInChaseRange();
            
            if (HasReachedDestination())
            {
                SetNextPatrolPoint(); 
            }
        }

        public void ExitState(ICharacter character)
        {
            
        }
        
        public bool HasReachedDestination()
        {
            return _agent.remainingDistance < 0.01f;
        }
        
        public void SetNextPatrolPoint()
        {
            _currentIndex = (_currentIndex + 1) % targets.Length;

            var rotateCommand = new RotateTowardsCommand(_enemy.transform, targets[_currentIndex].position, _rotationSpeed);
            rotateCommand.Execute();
            _footstepHandler.PlayFootstepSound();
            new SetDestinationCommand(_agent, targets[_currentIndex].position).Execute();
        }
    }
}
